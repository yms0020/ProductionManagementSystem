package com.production.server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import java.sql.SQLException;
import java.util.List;

import org.w3c.dom.Document;

import com.production.dao.ProductionDAO;
import com.production.dto.ProductionCreateRequest;
import com.production.dto.ProductionUpdateRequest;
import com.production.service.ProductionService;
import com.production.vo.ProductionVO;
import com.production.xml.ProductionXmlParser;

public class ProductionServer {

    private final ProductionService service =
            new ProductionService(new ProductionDAO());

    private final ProductionXmlParser parser =
            new ProductionXmlParser();

    public void start() throws IOException {

        try (ServerSocket server = new ServerSocket(9000)) {

            System.out.println("MES 서버 실행 중... PORT: 9000");

            while (true) {

                try (Socket client = server.accept()) {

                    System.out.println("클라이언트 연결 성공!");

                    client.setSoTimeout(100000);

                    DataInputStream in =
                            new DataInputStream(client.getInputStream());

                    DataOutputStream out =
                            new DataOutputStream(client.getOutputStream());

                    try {

                        int length = in.readInt();

                        if (length <= 0 || length > 1024 * 1024) {
                            throw new IOException("잘못된 메시지 길이");
                        }

                        byte[] buffer = new byte[length];

                        in.readFully(buffer);

                        String xml = new String(
                                buffer,
                                StandardCharsets.UTF_8
                        );

                        System.out.println("받은 XML: " + xml);

                        String response = processRequest(xml);

                        sendResponse(out, response);

                    } catch (Exception e) {
                    	
                        System.err.println(
                                "요청 처리 오류: " + e.getMessage()
                        );
                        
                        String message = "요청 처리 실패";
                        
                        if (e instanceof SQLException sqlEx) {

                            if (sqlEx.getErrorCode() == 1) {
                                message = "이미 존재하는 ResultId입니다.";
                            }
                        }

                        try {
                            sendResponse(
                                    out,
                                    "<Response>"
                                    + "<Success>false</Success>"
                                    + "<Message>" + message + "</Message>"
                                    + "</Response>"
                            );

                        } catch (IOException sendError) {

                            System.err.println(
                                    "응답 전송 실패: "
                                    + sendError.getMessage()
                            );
                        }
                    }

                } catch (IOException e) {

                    System.err.println(
                            "클라이언트 통신 오류: " + e.getMessage()
                    );
                }
            }
        }
    }

    private String processRequest(String xml) throws Exception {

        Document document = parser.parse(xml);

        String action = parser.getValue(document, "Action");

        switch (action) {

            case "INSERT": {

                ProductionCreateRequest request =
                        parser.parseInsert(document);

                int result = service.register(request);

                return resultResponse(result);
            }

            case "SELECT": {

                List<ProductionVO> list = service.findAll();

                StringBuilder sb = new StringBuilder();

                sb.append(
                        "<Response>"
                        + "<Success>true</Success>"
                        + "<Items>"
                );

                for (ProductionVO vo : list) {

                    sb.append("<Item>");

                    sb.append("<ResultId>")
                      .append(vo.getResultId())
                      .append("</ResultId>");

                    sb.append("<ProductCode>")
                      .append(escapeXml(vo.getProductCode()))
                      .append("</ProductCode>");

                    sb.append("<ProductName>")
                      .append(escapeXml(vo.getProductName()))
                      .append("</ProductName>");

                    sb.append("<Quantity>")
                      .append(vo.getQuantity())
                      .append("</Quantity>");

                    sb.append("<Status>")
                      .append(escapeXml(vo.getStatus()))
                      .append("</Status>");

                    sb.append("</Item>");
                }

                sb.append("</Items></Response>");

                return sb.toString();
            }

            case "UPDATE": {

            	 ProductionUpdateRequest request =
            	            parser.parseUpdate(document);

            	    int result = service.update(request);

            	    return resultResponse(result);
            }

            case "DELETE": {

                int resultId =
                        parser.getInt(document, "ResultId");

                int result = service.delete(resultId);

                return resultResponse(result);
            }

            default:
                throw new IllegalArgumentException(
                        "지원하지 않는 작업: " + action
                );
        }
    }

    private String resultResponse(int result) {

        if (result > 0) {
            return "<Response>"
                    + "<Success>true</Success>"
                    + "</Response>";
        }

        return "<Response>"
                + "<Success>false</Success>"
                + "</Response>";
    }

    private String escapeXml(String value) {

        if (value == null) {
            return "";
        }

        return value.replace("&", "&amp;")
                    .replace("<", "&lt;")
                    .replace(">", "&gt;")
                    .replace("\"", "&quot;")
                    .replace("'", "&apos;");
    }

    private void sendResponse(
            DataOutputStream out,
            String xml
    ) throws IOException {

        byte[] data =
                xml.getBytes(StandardCharsets.UTF_8);

        out.writeInt(data.length);
        out.write(data);
        out.flush();
    }
}