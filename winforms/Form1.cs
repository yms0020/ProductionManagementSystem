
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void txtResultId_TextChanged(
            object sender, EventArgs e)
        {
        }

        // Java 서버와 TCP 통신
        private string SendRequest(string xml)
        {
            using TcpClient client =
                new TcpClient("127.0.0.1", 9000);

            using NetworkStream stream = client.GetStream();

            stream.ReadTimeout = 10000;
            stream.WriteTimeout = 10000;

            // XML 요청을 UTF-8 바이트로 변환
            byte[] data = Encoding.UTF8.GetBytes(xml);

            // 요청 길이를 4바이트 Big-Endian으로 변환
            byte[] lengthBytes =
                BitConverter.GetBytes(data.Length);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }

            // Java 서버에 요청 전송
            stream.Write(lengthBytes, 0, lengthBytes.Length);
            stream.Write(data, 0, data.Length);
            stream.Flush();

            // 응답 길이 수신
            byte[] responseLengthBytes = new byte[4];

            stream.ReadExactly(responseLengthBytes);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(responseLengthBytes);
            }

            int responseLength =
                BitConverter.ToInt32(responseLengthBytes);

            if (responseLength <= 0 ||
                responseLength > 1024 * 1024)
            {
                throw new IOException(
                    "잘못된 응답 길이입니다.");
            }

            // XML 응답 수신
            byte[] responseBytes =
                new byte[responseLength];

            stream.ReadExactly(responseBytes);

            return Encoding.UTF8.GetString(responseBytes);
        }

        // 입력창 초기화
        private void ClearInputs()
        {
            txtResultId.Clear();
            txtProductCode.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            cmbStatus.SelectedIndex = -1;
        }

        // 등록 버튼 (INSERT)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string productCode =
                    txtProductCode.Text.Trim();

                string productName =
                    txtProductName.Text.Trim();

                string status = cmbStatus.Text;

                // 제품 코드 검사
                if (string.IsNullOrWhiteSpace(productCode))
                {
                    MessageBox.Show(
                        "제품 코드를 입력하세요.");
                    return;
                }

                // 생산 수량 검사
                if (!int.TryParse(
                    txtQuantity.Text, out int quantity)
                    || quantity <= 0)
                {
                    MessageBox.Show(
                        "생산 수량은 1 이상의 숫자로 입력하세요.");
                    return;
                }

                // 상태 검사
                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show(
                        "상태를 선택하세요.");
                    return;
                }

                // INSERT XML 생성
                string xml = new XElement("Request",
                    new XElement("Action", "INSERT"),
                    new XElement("ProductCode", productCode),
                    new XElement("ProductName", productName),
                    new XElement("Quantity", quantity),
                    new XElement("Status", status)
                ).ToString(SaveOptions.DisableFormatting);

                // Java 서버에 INSERT 요청
                string responseXml = SendRequest(xml);

                XDocument doc =
                    XDocument.Parse(responseXml);

                string success =
                    (string?)doc.Root?.Element("Success")
                    ?? "false";

                if (success == "true")
                {
                    MessageBox.Show(
                        "생산 실적 등록 성공!");

                    ClearInputs();

                    // 목록 새로고침
                    LoadProductionData();
                }
                else
                {
                    MessageBox.Show(
                        "생산 실적 등록 실패!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "등록 오류: " + ex.Message);
            }
        }

        // 조회 버튼 (SELECT)
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProductionData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "조회 오류: " + ex.Message);
            }
        }

        // 생산 실적 목록 조회
        private void LoadProductionData()
        {
            // SELECT XML 요청
            string xml =
                "<Request><Action>SELECT</Action></Request>";

            string responseXml = SendRequest(xml);

            XDocument doc =
                XDocument.Parse(responseXml);

            string success =
                (string?)doc.Root?.Element("Success")
                ?? "false";

            if (success != "true")
            {
                MessageBox.Show(
                    "조회에 실패했습니다.");
                return;
            }

            // XML 데이터를 목록으로 변환
            var items = doc.Descendants("Item")
                .Select(item => new
                {
                    ResultId =
                        (int)item.Element("ResultId")!,

                    ProductCode =
                        (string?)item.Element("ProductCode")
                        ?? "",

                    ProductName =
                        (string?)item.Element("ProductName")
                        ?? "",

                    Quantity =
                        (int)item.Element("Quantity")!,

                    Status =
                        (string?)item.Element("Status")
                        ?? ""
                })
                .OrderBy(item => item.ResultId)
                .ToList();

            // DataGridView에 데이터 표시
            dgvProduction.DataSource = null;

            dgvProduction.AutoGenerateColumns = true;

            dgvProduction.DataSource = items;

            // 컬럼 제목 설정
            dgvProduction.Columns["ResultId"]!.HeaderText =
                "실적 ID";

            dgvProduction.Columns["ProductCode"]!.HeaderText =
                "제품 코드";

            dgvProduction.Columns["ProductName"]!.HeaderText =
                "제품명";

            dgvProduction.Columns["Quantity"]!.HeaderText =
                "생산 수량";

            dgvProduction.Columns["Status"]!.HeaderText =
                "상태";
        }

        // DataGridView 행 클릭 이벤트
        private void dgvProduction_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            // 컬럼 제목 클릭 시 무시
            if (e.RowIndex < 0)
            {
                return;
            }

            // 클릭한 행 가져오기
            DataGridViewRow row =
                dgvProduction.Rows[e.RowIndex];

            // 실적 ID
            txtResultId.Text =
                row.Cells["ResultId"].Value?.ToString()
                ?? "";

            // 제품 코드
            txtProductCode.Text =
                row.Cells["ProductCode"].Value?.ToString()
                ?? "";

            // 제품명
            txtProductName.Text =
                row.Cells["ProductName"].Value?.ToString()
                ?? "";

            // 생산 수량
            txtQuantity.Text =
                row.Cells["Quantity"].Value?.ToString()
                ?? "";

            // 상태
            cmbStatus.Text =
                row.Cells["Status"].Value?.ToString()
                ?? "";
        }

        // 수정 버튼 (UPDATE)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // 수정할 실적 ID 확인
                if (!int.TryParse(
                    txtResultId.Text, out int resultId)
                    || resultId <= 0)
                {
                    MessageBox.Show(
                        "수정할 데이터를 먼저 선택하세요.");
                    return;
                }

                string productCode =
                    txtProductCode.Text.Trim();

                string productName =
                    txtProductName.Text.Trim();

                string status = cmbStatus.Text;

                // 제품 코드 검사
                if (string.IsNullOrWhiteSpace(productCode))
                {
                    MessageBox.Show(
                        "제품 코드를 입력하세요.");
                    return;
                }

                // 생산 수량 검사
                if (!int.TryParse(
                    txtQuantity.Text, out int quantity)
                    || quantity <= 0)
                {
                    MessageBox.Show(
                        "생산 수량은 1 이상의 숫자로 입력하세요.");
                    return;
                }

                // 상태 검사
                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show(
                        "상태를 선택하세요.");
                    return;
                }

                // UPDATE XML 생성
                string xml = new XElement("Request",
                    new XElement("Action", "UPDATE"),
                    new XElement("ResultId", resultId),
                    new XElement("ProductCode", productCode),
                    new XElement("ProductName", productName),
                    new XElement("Quantity", quantity),
                    new XElement("Status", status)
                ).ToString(SaveOptions.DisableFormatting);

                // Java 서버에 UPDATE 요청
                string responseXml = SendRequest(xml);

                XDocument doc =
                    XDocument.Parse(responseXml);

                string success =
                    (string?)doc.Root?.Element("Success")
                    ?? "false";

                if (success == "true")
                {
                    MessageBox.Show(
                        "생산 실적 수정 성공!");

                    ClearInputs();

                    // 목록 새로고침
                    LoadProductionData();
                }
                else
                {
                    MessageBox.Show(
                        "생산 실적 수정 실패!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "수정 오류: " + ex.Message);
            }
        }

        // 삭제 버튼 (DELETE)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 삭제할 실적 ID 확인
                if (!int.TryParse(
                    txtResultId.Text, out int resultId)
                    || resultId <= 0)
                {
                    MessageBox.Show(
                        "삭제할 데이터를 먼저 선택하세요.");
                    return;
                }

                // 삭제 확인 메시지
                DialogResult result = MessageBox.Show(
                    "실적 ID " + resultId +
                    "번 데이터를 정말 삭제하시겠습니까?",
                    "삭제 확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // 아니요를 누르면 삭제 취소
                if (result != DialogResult.Yes)
                {
                    return;
                }

                // DELETE XML 생성
                string xml = new XElement("Request",
                    new XElement("Action", "DELETE"),
                    new XElement("ResultId", resultId)
                ).ToString(SaveOptions.DisableFormatting);

                // Java 서버에 DELETE 요청
                string responseXml = SendRequest(xml);

                XDocument doc =
                    XDocument.Parse(responseXml);

                string success =
                    (string?)doc.Root?.Element("Success")
                    ?? "false";

                if (success == "true")
                {
                    MessageBox.Show(
                        "생산 실적 삭제 성공!");

                    // 입력창 초기화
                    ClearInputs();

                    // 목록 새로고침
                    LoadProductionData();
                }
                else
                {
                    MessageBox.Show(
                        "생산 실적 삭제 실패!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "삭제 오류: " + ex.Message);
            }
        }
    }
}
