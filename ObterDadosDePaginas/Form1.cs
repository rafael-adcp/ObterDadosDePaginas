using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObterDadosDePaginas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Visible = true;
            //após terminar de atualizar a página ele tenta buscar os dados novamente
            obterDados();
        }

        public void obterDados()
        {

            try
            {
                var possiveis = webBrowser1.Document.GetElementsByTagName("span");
                richTextBox1.Text = "";
                foreach (HtmlElement doc in possiveis)
                {
                    richTextBox1.Text += doc.OuterText + "\n";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
            webBrowser1.Navigate(webBrowser1.Url);
        }
    }
}


