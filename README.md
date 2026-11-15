# Production Management System
## 사용 기술

- Backend: Java 17, JDBC, Maven
- Frontend: C# WinForms
- Database: Oracle Database
- Communication: TCP Socket, XML
- IDE: Eclipse, Visual Studio

## 주요 기능

- 생산 실적 등록 (INSERT)
- 생산 실적 전체 조회 (SELECT)
- 생산 실적 수정 (UPDATE)
- 생산 실적 삭제 (DELETE)
- DataGridView를 통한 생산 실적 목록 표시

## 프로젝트 구조

- ProductionServer: Java 서버 및 Oracle DB 연동
- winforms: C# WinForms 클라이언트

## 시스템 구성

C# WinForms Client
        |
    TCP Socket
        |
    Java Server
        |
      JDBC
        |
  Oracle Database
