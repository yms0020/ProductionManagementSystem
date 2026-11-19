package com.production.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBUtil {

	public static Connection getConnection() throws SQLException {
	
		String url = "jdbc:oracle:thin:@//localhost:1521/EDU";
		
		String username = "webuser";
		String password = "webuser";
		
		return DriverManager.getConnection(url, username, password);
		
	}
}
