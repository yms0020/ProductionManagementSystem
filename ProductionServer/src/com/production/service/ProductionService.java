
package com.production.service;

import java.sql.SQLException;
import java.util.List;

import com.production.dao.ProductionDAO;
import com.production.dto.ProductionCreateRequest;
import com.production.dto.ProductionUpdateRequest;
import com.production.vo.ProductionVO;

public class ProductionService {

    private final ProductionDAO dao;

    public ProductionService(ProductionDAO dao) {
        this.dao = dao;
    }

    // INSERT
    public int register(ProductionCreateRequest request) throws SQLException {

        if (request == null) {
            throw new IllegalArgumentException("생산 실적 정보가 없습니다.");
        }

        if (request.getResultId() <= 0) {
            throw new IllegalArgumentException("ResultId는 1 이상이어야 합니다.");
        }

        if (request.getProductCode() == null || request.getProductCode().isBlank()) {
            throw new IllegalArgumentException("제품 코드는 필수입니다.");
        }

        if (request.getQuantity() <= 0) {
            throw new IllegalArgumentException("생산 수량은 1 이상이어야 합니다.");
        }

        ProductionVO vo = new ProductionVO(
                request.getResultId(),
                request.getProductCode(),
                request.getProductName(),
                request.getQuantity(),
                request.getStatus()
        );

        return dao.insert(vo);
    }

    // SELECT
    public List<ProductionVO> findAll() throws SQLException {
        return dao.findAll();
    }

    // UPDATE
    public int update(ProductionUpdateRequest request) throws SQLException {

        if (request == null) {
            throw new IllegalArgumentException("생산 실적 정보가 없습니다.");
        }

        if (request.getResultId() <= 0) {
            throw new IllegalArgumentException("잘못된 ResultId입니다.");
        }

        if (request.getProductCode() == null || request.getProductCode().isBlank()) {
            throw new IllegalArgumentException("제품 코드가 필수입니다.");
        }

        if (request.getQuantity() <= 0) {
            throw new IllegalArgumentException("생산 수량은 1 이상이어야 합니다.");
        }
        
        if(request.getPreviousResultId() <= 0) {
        	throw new IllegalArgumentException("잘못된 ResultId입니다.");
        }

        ProductionVO vo = new ProductionVO(
                request.getResultId(),
                request.getProductCode(),
                request.getProductName(),
                request.getQuantity(),
                request.getStatus()
        );

        return dao.update(request.getPreviousResultId(),vo);
    }

    // DELETE
    public int delete(int resultId) throws SQLException {

        if (resultId <= 0) {
            throw new IllegalArgumentException("잘못된 ResultId입니다.");
        }

        return dao.delete(resultId);
    }
}
