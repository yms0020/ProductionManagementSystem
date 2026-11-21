using System.CodeDom;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProductionClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dgvProduction.AutoGenerateColumns = false; //열 자동 생성 끄기

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshProductionGrid();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e) // 데이터 삽입(ResultId는 자동 생성)
        {
            try
            {
                if (!int.TryParse(txtResultId.Text.Trim(), out int resultId) || resultId <= 0)
                {
                    MessageBox.Show("실적 ID는 1 이상의 숫자로 입력하세요.");
                    return;
                }

                string productCode = txtProductCode.Text.Trim(); //입력 박스에 데이터 추출

                string productName = txtProductName.Text.Trim();

                int quantity = int.Parse(txtQuantity.Text.Trim());

                string status = cmbStatus.Text;

                //제품 코드 검사
                if (productCode == null || string.IsNullOrWhiteSpace(productCode))
                {
                    MessageBox.Show("제품 코드를 입력하세요");
                    return;
                }

                //제품 코드 검사
                if (productName == null || string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("제품 이름을 입력하세요");
                    return;
                }

                //생산 수량
                if (quantity <= 0)
                {
                    MessageBox.Show("생산 수량은 1 이상의 숫자로 입력하세요");
                    return;
                }

                //상태 검사
                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("상태를 선택 해주세요.");
                    return;
                }

                //xml 생성
                string xml = new XElement("Request",
                    new XElement("Action", "INSERT"),
                    new XElement("ResultId", resultId),
                    new XElement("ProductCode", productCode),
                    new XElement("ProductName", productName),
                    new XElement("Quantity", quantity),
                    new XElement("Status", status)
                    ).ToString(SaveOptions.DisableFormatting); //들여쓰기와 줄바꿈을 없애는 옵션.

                string responseXml = sendRequest(xml);

                XDocument doc = XDocument.Parse(responseXml);

                string success = (string?)doc.Root?.Element("Success") ?? "false";

                if (success == "true")
                {
                    MessageBox.Show("데이터 등록 완료!");
                    ClearInputs(); //입력 데이터 제거
                    RefreshProductionGrid(); //새로 고침 한 뒤 조회
                }
                else
                {
                    string message = (string?)doc.Root?.Element("Message")
                     ?? "데이터 변경 거부";
                    throw new InvalidOperationException(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("등록 오류 : " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) //값 수정
        {
            try
            {
                int resultId = int.Parse(txtResultId.Text);
                string? productCode = txtProductCode.Text.Trim();
                string? productName = txtProductName.Text.Trim();
                int quantity = int.Parse(txtQuantity.Text);
                string? status = cmbStatus.Text;

                //입력값 검사

                //실적 ID 검사
                if (resultId <= 0)
                {
                    MessageBox.Show("수정할 데이터를 선택하세요.");
                    return;
                }

                //제품 코드 검사
                if (productCode == null || string.IsNullOrWhiteSpace(productCode))
                {
                    MessageBox.Show("제품 코드를 입력하세요");
                    return;
                }

                //제품 코드 검사
                if (productName == null || string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("제품 이름을 입력하세요");
                    return;
                }

                //생산 수량
                if (quantity <= 0)
                {
                    MessageBox.Show("생산 수량은 1 이상의 숫자로 입력하세요");
                    return;
                }

                //상태 검사
                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("상태를 선택 해주세요.");
                    return;
                }

                //XML 생성
                string xml = new XElement("Request",
                    new XElement("ResultId", resultId),
                    new XElement("Action", "UPDATE"),
                    new XElement("ProductCode", productCode),
                    new XElement("ProductName", productName),
                    new XElement("Quantity", quantity),
                    new XElement("Status", status)
                    ).ToString(SaveOptions.DisableFormatting);

                //전송 후 응답
                string responseXml = sendRequest(xml);

                //응답 XML 파싱
                XDocument doc = XDocument.Parse(responseXml);

                //결과를 반환
                string success = (string?)doc.Root?.Element("Success") ?? "false";

                if (success == "true")
                {
                    MessageBox.Show(xml);
                    MessageBox.Show("데이터 변경 확인");
                    RefreshProductionGrid();
                    ClearInputs();
                }
                else
                {
                    string message = (string?)doc.Root?.Element("Message")
                     ?? "데이터 변경 거부";
                    throw new InvalidOperationException(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("번경 오류 : " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int resultId = int.Parse(txtResultId.Text); //WHERE가 삭제에 필요

                if (resultId <= 0) //실적 ID 검사
                {
                    MessageBox.Show("삭제할 데이터를 선택하세요.");
                    return;
                }

                DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }

                // XML 생성
                string xml = new XElement("Request",
                    new XElement("ResultId", resultId),
                    new XElement("Action", "DELETE")
                    ).ToString(SaveOptions.DisableFormatting);

                // XML 생성 및 응답
                string responseXml = sendRequest(xml);

                // XML 파싱
                XDocument doc = XDocument.Parse(responseXml);

                // 반환 여부
                string? success = (string?)doc.Root?.Element("Success") ?? "false";

                if (success == "true")
                {
                    MessageBox.Show("데이터가 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    RefreshProductionGrid();
                }
                else
                {
                    throw new InvalidOperationException("데이터 삭제 거부");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 거부 : " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string sendRequest(string xml)
        {
            using TcpClient tcpClient = new TcpClient("127.0.0.1", 9000); //C#이 tcp 통신을 하기 위한 문

            using NetworkStream stream = tcpClient.GetStream(); //연결된 서버의 데이터 교환 통로

            stream.ReadTimeout = 100000; //응답 시간제한 10초
            stream.WriteTimeout = 100000; //요청 시간제한 10초

            byte[] data = Encoding.UTF8.GetBytes(xml); //tcp는 바이트로 통신하므로 문자열을 바이트로 변환을 해야한다.

            byte[] lengthBytes = BitConverter.GetBytes(data.Length); //BitConverter.GetBytes()는 숫자형 값을 바이트 배열(byte[])로 변환하는 메서드

            // data 배열의 길이를 byte[]로 변환하는 이유는
            // Java 서버에 전송할 XML 데이터의 크기를 4바이트로 알려주기 위해서이다. 4바이트인 이유는 int가 4바이트이며 충분한 표현 가능 숫자가 되기 때문에
            // 길이를 보내는 이유는 TCP에는 메시지의 끝을 구분하는 기능이 없기 때문에, Java 서버가 XML 데이터를 몇 바이트까지 읽어야 하는지 알 수 있도록 하기 위해.

            // 현재 프로젝트는 자바 서버가 길이 정보를 Big-Endian으로 데이터를 읽기 때문에 C#도 확인을 한 뒤 변환해줘야 한다
            //BitConverter → 숫자와 바이트를 변환하는 클래스
            //IsLittleEndian → 리틀엔디언인지 확인하는 프로퍼티
            // Little-endian,Big-endian 예시
            //EX : 정수 258을 4 바이트로 표현하면 바이트 순서에 의해
            //Little-endian: 02 01 00 00 (작은 자리값의 바이트부터 저장) 
            //Big-endian: 00 00 01 02 (큰 자리값의 바이트부터 저장)

            if (BitConverter.IsLittleEndian) //현재 컴퓨터가 리틀엔디언(Little-endian) 방식으로 데이터를 저장하는지 확인하는 C# 프로퍼티
            {
                Array.Reverse(lengthBytes); //배열의 순서를 뒤집어 준다.
            }

            //TCP 전송 (stream.Write(바이트 배열,시작위치,전송할 데이터 개수 stream.Flush()는 버퍼에 남은 데이터 내보내는 역활)
            stream.Write(lengthBytes, 0, lengthBytes.Length); //길이를 먼저 전송
            stream.Write(data, 0, data.Length); //데이터 전송

            //자바 서버로 부터 응답(byte -> int)
            byte[] responseLengthBytes = new byte[4]; //응답 길이 정보를 받을 4바이트 배열을 초기화

            stream.ReadExactly(responseLengthBytes); //Java 서버가 보낸 응답 길이 정보 4바이트를 배열에 저장한다. ReadExactly()는 배열이 가득 찰 때까지 읽으며 반환형은 void 서버가 중간에 끊기면 4바이트 모두 읽지 못 하므로 예외 발생

            if (BitConverter.IsLittleEndian) //현재 시스템이 Little-Eldian 인지 확인을 한다(사실 시슽템이 바뀔 이유는 없지만 처리 배열이 다르기 때문에)
            {
                Array.Reverse(responseLengthBytes);
            }

            int responseLength = BitConverter.ToInt32(responseLengthBytes); //Java 서버가 보낸 XML 데이터의 길이

            byte[] responseBytes = new byte[responseLength]; //해당 길이만큼 데이터를 담을 바이트 배열 생성

            stream.ReadExactly(responseBytes); //자바 서버가 보낸 실제 XML 데이터를 responseBytes 배열 크기만큼 읽어 배열에 데이터를 저장

            return Encoding.UTF8.GetString(responseBytes); //바이트 배열을 문자열로 전환
        }


        private void ClearInputs() //텍스트 박스 및 콤보 박스 입력 텍스트 초기화
        {
            //TextBox.Clear()는 텍스트 박스에 입력된 글자를 지우는 메서드
            //ComboBox.Items.Clear()는 Item 속성의 컬렉션들을 모두 지워서 선택지를 없앤다
            //ComboBox.SelectedIndex = -1은 항목들은 그대로 두고 현재 선택만 해제(0은 첫번째 선택지부터)
            txtProductCode.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            txtResultId.Clear();
            cmbStatus.SelectedIndex = -1; //Items와 SelectedIndex는 ComboBox의 속성이다.

            txtResultId.ReadOnly = false;
        }

        private List<ProductionDTO> LoadProductionData() //조회 데이터 List 형태로 받는다.
        {
            List<ProductionDTO> dto = new List<ProductionDTO>();

            string xml = "<Request><Action>SELECT</Action></Request>";

            string responseXml = sendRequest(xml);

            XDocument doc = XDocument.Parse(responseXml); //XML문자열을 분석해서 원하는 태그와 값을 가져올 수 있는 클래스

            string? success = doc.Root?.Element("Success")?.Value; //null이 가능한 string형에 태그가 Success인 데이터 꺼낸다. null일 땐 null 출력을 한다.

            if (!bool.TryParse(success, out bool isSuccess) || !isSuccess)  //변환에 실패했거나, 변환된 값이 false라면 조회 실패로 처리를 한다
            {
                throw new InvalidOperationException("조회를 실패했습니다.");
            }

            foreach (XElement item in doc.Root!.Descendants("Item")) //XElement item → XML 요소 하나를 저장할 변수
            {
                int resultID = (int)item.Element("ResultId")!; //!는 컴파일러의 null 경고를 억제하며, 런타임 예외는 방지하지 않음
                string? productCode = (string)item.Element("ProductCode")!;
                string? productName = (string)item.Element("ProductName")!;
                int quantity = (int)item.Element("Quantity")!;
                string? status = (string)item.Element("Status")!;

                ProductionDTO productionDTO = new ProductionDTO
                {
                    ResultId = resultID,
                    ProductCode = productCode ?? string.Empty,
                    ProductName = productName ?? string.Empty,
                    Quantity = quantity,
                    Status = status ?? string.Empty
                };

                dto.Add(productionDTO);

            }
            dto = dto.OrderBy(x => x.ResultId).ToList();//정렬

            return dto;
        }

        private void RefreshProductionGrid()
        {
            List<ProductionDTO> list = LoadProductionData();

            dgvProduction.DataSource = list; //그리드 데이터 

        }

        private void dgvProduction_CellClick(object sender, DataGridViewCellEventArgs e) //그리드 행 선택
        {
            // DataGridViewCellEventArgs e의 e.RowIndex는 사용자가 클릭한 행의 인덱스 번호를 알려준다.0부터 시작
            // 열 제목을 클릭하면은 -1이 선택이 된다.

            if (e.RowIndex < 0)
            {
                return; //열을 선택을 했으면 메서드 종료
            }

            DataGridViewRow row = dgvProduction.Rows[e.RowIndex]; //dgvProduction.Rows : DataGridView의 행 모음, [e.RowIndex] → 클릭한 행의 인덱스, row → 가져온 행을 저장하는 변수
            //row.Cells[0] → 첫 번째 열(ResultId
            //row.Cells[1] → 두 번째 열(ProductCode
            //row.Cells["ProductName"] → ProductName이라는 이름의 열

            txtResultId.Text = row.Cells[0].Value?.ToString() ?? "";
            txtProductCode.Text = row.Cells[1].Value?.ToString() ?? "";
            txtProductName.Text = row.Cells[2].Value?.ToString() ?? "";
            txtQuantity.Text = row.Cells[3].Value?.ToString() ?? "";
            cmbStatus.Text = row.Cells[4].Value?.ToString() ?? "";

            txtResultId.ReadOnly = true;

        }

        private void dgvProduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOpenSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(); //검색창 객체 생성
            if (searchForm.ShowDialog() == DialogResult.OK) //검색창을 열고 닫힐 때까지 기다림 == 사용자가 검색 버튼을 눌러 정상적으로 종료했는지 확인
            {
                string searchType = searchForm.SearchType; //검색 조건 가져오기
                string keyword = searchForm.Keyword; //검색어 가져오기

                string xml = new XElement("Request",
                new XElement("Action", "SEARCH"),
                new XElement("SearchType", searchType),
                new XElement("Keyword", keyword)
                ).ToString(SaveOptions.DisableFormatting);


                string responseXml = sendRequest(xml);

                MessageBox.Show(responseXml);

                XDocument doc = XDocument.Parse(responseXml);

                string? success = doc.Root?.Element("Success")?.Value;

                if (success == "true")
                {
                    List<ProductionDTO> searchResults = new List<ProductionDTO>();

                    foreach (XElement item in doc.Root!.Descendants("Item"))
                    {
                        ProductionDTO productionDTO = new ProductionDTO
                        {
                            ResultId = (int)item.Element("ResultId")!,
                            ProductCode = (string?)item.Element("ProductCode") ?? string.Empty,
                            ProductName = (string?)item.Element("ProductName") ?? string.Empty,
                            Quantity = (int)item.Element("Quantity")!,
                            Status = (string?)item.Element("Status") ?? string.Empty
                        };

                        searchResults.Add(productionDTO);
                    }

                    dgvProduction.DataSource = null;
                    dgvProduction.DataSource = searchResults.OrderBy(x => x.ResultId).ToList();
                }
                else
                {
                    MessageBox.Show("검색 실패");
                }
            } 
        }
    }


}
