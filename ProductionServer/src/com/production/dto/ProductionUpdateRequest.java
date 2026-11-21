
package com.production.dto;

public class ProductionUpdateRequest {

    private int resultId;
    private String productCode;
    private String productName;
    private int quantity;
    private String status;

    // 기본 생성자
    public ProductionUpdateRequest() {
    }

	// 매개변수 생성자
    public ProductionUpdateRequest(
            int resultId,
            String productCode,
            String productName,
            int quantity,
            String status
            ) {

        this.resultId = resultId;
        this.productCode = productCode;
        this.productName = productName;
        this.quantity = quantity;
        this.status = status;
    }
    
    public int getResultId() {
        return resultId;
    }

    public void setResultId(int resultId) {
        this.resultId = resultId;
    }

    public String getProductCode() {
        return productCode;
    }

    public void setProductCode(String productCode) {
        this.productCode = productCode;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
