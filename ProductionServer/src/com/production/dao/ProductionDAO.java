package com.production.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.production.util.DBUtil;
import com.production.vo.ProductionVO;

public class ProductionDAO {
	
	public List<ProductionVO> findAll() throws SQLException {
		
		String sql = "SELECT * FROM PRODUCTION_RESULT";

		List<ProductionVO> list = new ArrayList<>();
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql);
						      ResultSet rs = pstmt.executeQuery()) {
			
			System.out.println("SELECT 실행 성공!");
			
			while(rs.next()) {
				
				ProductionVO vo = new ProductionVO(); 
				
				vo.setResultId(rs.getInt("Result_ID"));
				vo.setProductCode(rs.getString("PRODUCT_CODE"));
				vo.setProductName(rs.getString("PRODUCT_NAME"));
				vo.setQuantity(rs.getInt("QUANTITY"));
				vo.setStatus(rs.getString("STATUS"));
				
				list.add(vo);
			}
		}
		return list;
	}
	
	public int insert(ProductionVO vo) throws SQLException {
		
		String sql = "INSERT INTO PRODUCTION_RESULT "
					+ "(PRODUCT_CODE,PRODUCT_NAME,QUANTITY,STATUS) "
					+ "VALUES (?,?,?,?)";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql)) {
			
			pstmt.setString(1,vo.getProductCode());
			pstmt.setString(2,vo.getProductName());
			pstmt.setInt(3, vo.getQuantity());
			pstmt.setString(4,vo.getStatus());
			
			int result = pstmt.executeUpdate();
			return result;
		} 			
	}
	
	public int update(int resultId,ProductionVO vo) throws SQLException {
		
		String sql = "UPDATE PRODUCTION_RESULT "
					+"SET PRODUCT_CODE = ?, "
					+"PRODUCT_NAME = ?, "
					+"QUANTITY = ?, "
					+"STATUS = ? "
					+"WHERE RESULT_ID = ?";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql)) {
			
			pstmt.setString(1,vo.getProductCode());
			pstmt.setString(2, vo.getProductName());
			pstmt.setInt(3,vo.getQuantity());
			pstmt.setString(4, vo.getStatus());
			pstmt.setInt(5, resultId);
			
			int result = pstmt.executeUpdate();
			return result;
		}
	}
	public int delete(int resultId) throws SQLException {
		
		String sql = "DELETE FROM PRODUCTION_RESULT WHERE RESULT_ID = ?";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql)) {
			
			pstmt.setInt(1,resultId);
		
			int result = pstmt.executeUpdate();
			return result;
		}
	}
}
