package com.production.xml;

import java.io.StringReader;

import javax.xml.XMLConstants;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

import com.production.dto.ProductionCreateRequest;
import com.production.dto.ProductionUpdateRequest;

public class ProductionXmlParser {

    public Document parse(String xml) throws Exception {

        DocumentBuilderFactory factory =
                DocumentBuilderFactory.newInstance();

        factory.setFeature(
                "http://apache.org/xml/features/disallow-doctype-decl",
                true
        );

        factory.setFeature(
                XMLConstants.FEATURE_SECURE_PROCESSING,
                true
        );

        factory.setXIncludeAware(false);
        factory.setExpandEntityReferences(false);

        factory.setAttribute(
                XMLConstants.ACCESS_EXTERNAL_DTD, ""
        );

        factory.setAttribute(
                XMLConstants.ACCESS_EXTERNAL_SCHEMA, ""
        );

        Document document = factory.newDocumentBuilder()
                .parse(new InputSource(new StringReader(xml)));

        if (!"Request".equals(
                document.getDocumentElement().getTagName())) {

            throw new IllegalArgumentException(
                    "잘못된 XML 요청 형식"
            );
        }

        return document;
    }

    public String getValue(Document document, String tagName) {

        NodeList nodes = document.getDocumentElement()
                .getElementsByTagName(tagName);

        if (nodes.getLength() == 0) {
            throw new IllegalArgumentException(
                    "필수 태그 누락: " + tagName
            );
        }

        return nodes.item(0).getTextContent().trim();
    }

    public int getInt(Document document, String tagName) {

        return Integer.parseInt(
                getValue(document, tagName)
        );
    }

    public ProductionCreateRequest parseInsert(Document document) {

    	return new ProductionCreateRequest(
                getInt(document, "ResultId"),
                getValue(document, "ProductCode"),
                getValue(document, "ProductName"),
                getInt(document, "Quantity"),
                getValue(document, "Status")
        );
    }

    public ProductionUpdateRequest parseUpdate(Document document) {

    	return new ProductionUpdateRequest(
                getInt(document, "ResultId"),
                getValue(document, "ProductCode"),
                getValue(document, "ProductName"),
                getInt(document, "Quantity"),
                getValue(document, "Status"),
                getInt(document, "PreviousResultId")
        );
    }
}