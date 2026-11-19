
package com.production.dto;

public class ProductionUpdateRequest {

    private int resultId;
    private String productCode;
    private String productName;
    private int quantity;
    private String status;
    private int previousResultId;

    // 기본 생성자
    public ProductionUpdateRequest() {
    }

	// 매개변수 생성자
    public ProductionUpdateRequest(
            int resultId,
            String productCode,
            String productName,
            int quantity,
            String status,
            int previousResultId) {

        this.resultId = resultId;
        this.productCode = productCode;
        this.productName = productName;
        this.quantity = quantity;
        this.status = status;
        this.previousResultId = previousResultId;
    }

    public int getPreviousResultId() {
		return previousResultId;
	}

	public void setPreviousResultId(int previousResultId) {
		this.previousResultId = previousResultId;
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
