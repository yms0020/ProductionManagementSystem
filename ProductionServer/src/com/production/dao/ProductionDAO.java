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
		
		String sql = "SELECT * FROM PRODUCTION_RESULT1";

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
		
//		String sql = "INSERT INTO PRODUCTION_RESULT1 "
//		           + "(RESULT_ID,PRODUCT_CODE,PRODUCT_NAME,QUANTITY,STATUS) "
//		           + "VALUES (?,?,?,?,?)";
		
		String sql = "MERGE INTO PRODUCTION_RESULT1 t "
	               + "USING (SELECT ? AS RESULT_ID, "
	               + "              ? AS PRODUCT_CODE, "
	               + "              ? AS PRODUCT_NAME, "
	               + "              ? AS QUANTITY, "
	               + "              ? AS STATUS FROM DUAL) s "
	               + "ON (t.RESULT_ID = s.RESULT_ID) "
	               + "WHEN NOT MATCHED THEN "
	               + "INSERT (RESULT_ID, PRODUCT_CODE, PRODUCT_NAME, QUANTITY, STATUS) "
	               + "VALUES (s.RESULT_ID, s.PRODUCT_CODE, s.PRODUCT_NAME, s.QUANTITY, s.STATUS)";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql)) {
			
			
			pstmt.setInt(1, vo.getResultId());
			pstmt.setString(2, vo.getProductCode());
			pstmt.setString(3, vo.getProductName());
			pstmt.setInt(4, vo.getQuantity());
			pstmt.setString(5, vo.getStatus());
			
			int result = pstmt.executeUpdate();
			
			return result;
		} 			
	}
	
	public int update(ProductionVO vo) throws SQLException {
		
		String sql = "UPDATE PRODUCTION_RESULT1 "
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
			pstmt.setInt(5, vo.getResultId());
			
			int result = pstmt.executeUpdate();
			System.out.println("UPDATE 실행 결과: " + result);
			return result;
		}
	}
	public int delete(int resultId) throws SQLException {
		
		String sql = "DELETE FROM PRODUCTION_RESULT1 WHERE RESULT_ID = ?";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql)) {
			
			pstmt.setInt(1,resultId);
		
			int result = pstmt.executeUpdate();
			return result;
		}
	}
	
	public boolean existsByResultId(int resultId) throws SQLException { //result가 이미 있는지 확인 로직
		String sql = "SELECT COUNT(*) "
				+ "FROM PRODUCTION_RESULT1 "
				+ "WHERE RESULT_ID = ?";
		
		try(Connection conn = DBUtil.getConnection();
							  PreparedStatement pstmt = conn.prepareStatement(sql);) {
			
			pstmt.setInt(1, resultId);
			
			try (ResultSet rs = pstmt.executeQuery()) {

		        if (rs.next()) {
		            int count = rs.getInt(1); //getInt(1)은 현재 행의 첫 번째 칼럼 값을 int로 가져온다.

		            return count > 0; // boolean
		        }
		        
		        return false;
		        
//		        prepareStatement() → SQL 준비
//		        setInt() → SQL의 ?에 ResultId 설정
//		        executeQuery() → SQL 실행
//		        rs.next() → 조회 결과 행으로 이동
//		        rs.getInt(1) → 조회된 개수 확인
			}
		}
	}
		
		public List<ProductionVO> search(String searchType, String keyword) throws SQLException {
			
			String columnName;

			if (searchType.equals("RESULT_ID")) {
			    columnName = "RESULT_ID";

			} else if (searchType.equals("PRODUCT_CODE")) {
			    columnName = "PRODUCT_CODE";

			} else if (searchType.equals("PRODUCT_NAME")) {
			    columnName = "PRODUCT_NAME";

			} else if (searchType.equals("QUANTITY")) {
			    columnName = "QUANTITY";

			} else if (searchType.equals("STATUS")) {
			    columnName = "STATUS";

			} else {
			    throw new IllegalArgumentException("지원하지 않는 검색 조건입니다.");
			}
			
			String sql = "SELECT * FROM PRODUCTION_RESULT1 WHERE " + columnName + " = ?";
			
			try(Connection conn = DBUtil.getConnection(); 
								  PreparedStatement pstmt = conn.prepareStatement(sql);) {
				
				if(searchType.equals("RESULT_ID")||searchType.equals("QUANTITY")) {
					pstmt.setInt(1, Integer.parseInt(keyword));
				} else if(searchType.equals("PRODUCT_CODE")||searchType.equals("PRODUCT_NAME")||searchType.equals("STATUS")) {
					pstmt.setString(1,keyword);
				} else {throw new IllegalArgumentException("지원하지 않는 검색 조건입니다.");}
				
				List<ProductionVO> list = new ArrayList<>();
				
				try(ResultSet rs = pstmt.executeQuery()) {
					
					while(rs.next()) {
						ProductionVO vo = new ProductionVO();
						
						vo.setResultId(rs.getInt("Result_ID"));
						vo.setProductCode(rs.getString("PRODUCT_CODE"));
						vo.setProductName(rs.getString("PRODUCT_NAME"));
						vo.setQuantity(rs.getInt("QUANTITY"));
						vo.setStatus(rs.getString("STATUS"));
						
						list.add(vo);
					}
					return list;
				}
			}
		} 
}
