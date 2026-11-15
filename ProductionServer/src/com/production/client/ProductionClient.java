package com.production.client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class ProductionClient {

    public static void main(String[] args) {

    	String xml =
    	        "<Request>"
    	        + "<Action>DELETE</Action>"
    	        + "<ResultId>24</ResultId>"
    	        + "</Request>";

        try (Socket socket = new Socket("localhost", 9000)) {

            System.out.println("서버 연결 성공!");

            DataOutputStream out =
                    new DataOutputStream(socket.getOutputStream());

            DataInputStream in =
                    new DataInputStream(socket.getInputStream());

            // XML을 UTF-8 바이트로 변환
            byte[] data = xml.getBytes(StandardCharsets.UTF_8);

            // 4바이트 메시지 길이 전송
            out.writeInt(data.length);

            // XML 데이터 전송
            out.write(data);
            out.flush();

            System.out.println("XML 요청 전송 완료!");

            // 서버 응답 길이 읽기
            int length = in.readInt();

            if (length <= 0 || length > 1024 * 1024) {
                throw new IOException("잘못된 응답 길이");
            }

            // 서버 응답 데이터 읽기
            byte[] buffer = new byte[length];
            in.readFully(buffer);

            String response =
                    new String(buffer, StandardCharsets.UTF_8);

            System.out.println("서버 응답: " + response);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}