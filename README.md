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

## Oracle DB 설정

프로젝트 실행 전 Oracle Database 환경 설정이 필요합니다.

### 1. DB 연결 설정

`ProductionServer/src/com/production/util/DBUtil.java` 파일에서 본인의 Oracle DB 환경에 맞게 다음 정보를 설정해야 합니다.

- **DB URL** : Oracle 데이터베이스 접속 주소
- **DB Username** : Oracle 사용자 계정
- **DB Password** : Oracle 사용자 비밀번호

### 2. 테이블 생성

Oracle DB에 접속한 후 다음 SQL을 실행하여 `PRODUCTION_RESULT` 테이블을 생성합니다.

```sql
CREATE TABLE PRODUCTION_RESULT (
    RESULT_ID NUMBER(10) GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    PRODUCT_CODE VARCHAR2(30),
    PRODUCT_NAME VARCHAR2(100),
    QUANTITY NUMBER(10),
    STATUS VARCHAR2(20)
);
```

`RESULT_ID`는 Oracle의 `IDENTITY` 기능으로 자동 생성됩니다.

### 3. 프로젝트 실행

1. Oracle DB 실행 및 연결 확인
2. `DBUtil.java`의 DB 연결 정보 설정
3. `PRODUCTION_RESULT` 테이블 생성
4. Java 서버 실행
5. C# WinForms 클라이언트 실행
