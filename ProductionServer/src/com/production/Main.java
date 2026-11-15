package com.production;

import java.io.IOException;

import com.production.server.ProductionServer;

public class Main {

    public static void main(String[] args) {

        try {

            ProductionServer server = new ProductionServer();

            server.start();

        } catch (IOException e) {

            e.printStackTrace();

        }
    }
}