using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

namespace AssinaturaDigital
{
    public partial class Home: System.Windows.Forms.Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document pdfDocument = new Document(txtDocumento.Text);
            PdfFileSignature signature = new PdfFileSignature(pdfDocument);
            PKCS7 pkcs = new PKCS7(txtCertificado.Text, txtSenha.Text);
            DocMDPSignature docMdpSignature = new DocMDPSignature(pkcs, DocMDPAccessPermissions.FillingInForms);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 600, 100);
            signature.Certify(1, "Validação de teste", "Eliano Cordeiro", "Alfenas.MG", true, rect, docMdpSignature);
            signature.Save(txtSalvar.Text+"Digitally Signed PDF.pdf");

            MessageBox.Show("Assinado com sucesso!");
            txtDocumento.Text = "";
            txtCertificado.Text = "";
            txtSenha.Text = "";
            txtSalvar.Text = "";
        }
    }
}
