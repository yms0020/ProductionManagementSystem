package com.production.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBUtil {

	public static Connection getConnection() throws SQLException {
	
		String url = "";
		
		String username = "";
		String password = "";
		
		return DriverManager.getConnection(url, username, password);
		
	}
}
