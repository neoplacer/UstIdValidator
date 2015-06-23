using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Text;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CookComputing.XmlRpc;

namespace UstIdValidator
{
    delegate void AppendExceptionDelegate(Exception ex);
    delegate void AppendSuccessDelegate(string result);

    public partial class Form1 : Form
    {
        Dictionary<string, string> returndata;
        public Form1()
        {
            InitializeComponent();

        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Bitte warten!";
            stbarlblStatus.Text = "";
            cmdValidate.Enabled = false;            
            lblStatus.ForeColor = System.Drawing.Color.Black;
            prgBar.Value = 0;
            IntEvatrRPC ustidVaildaterXMLRPC = XmlRpcProxyGen.Create<IntEvatrRPC>();
            ustidVaildaterXMLRPC.Timeout = 10000;
            try
            {
                //Regex rgx = new Regex("[^A-Z0-9 -]");
                txtUstIDDE.Text = Regex.Replace(txtUstIDDE.Text, @"[^A-Z\d]", String.Empty);
                txtUstIDREG.Text = Regex.Replace(txtUstIDREG.Text, @"[^A-Z\d]", String.Empty);
                //txtUstIDDE.Text.Replace(c""
                returndata = new Dictionary<string, string>();
                string U_IDDE = txtUstIDDE.Text;
                string U_IDREQ = txtUstIDREG.Text;
                string U_FIRM = "";
                string U_ORT = "";
                string U_PLZ = "";
                string U_STR = "";
                string U_PRI = "";
                AsyncCallback acb = new AsyncCallback(GetVaildateIDCallback);
                IntEvatrRPCAsyncState asyncUsidState = new IntEvatrRPCAsyncState(U_IDDE, U_IDREQ, U_FIRM, U_ORT, U_PLZ, U_STR, U_PRI, this);
                IAsyncResult asr = ustidVaildaterXMLRPC.BeginVaildateID(U_IDDE, U_IDREQ, U_FIRM, U_ORT, U_PLZ, U_STR, U_PRI, acb, asyncUsidState);
                if (asr.CompletedSynchronously)
                {
                    string ret = ustidVaildaterXMLRPC.EndVaildateID(asr);
                    AppendSuccess(ret);
                }

            }
            catch (Exception ex)
            {
                cmdValidate.Enabled = true;
                AppendException(ex);
            }

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        private void AppendException(Exception ex)
        {
            string s;
            try
            {
                throw ex;
            }
            catch (XmlRpcFaultException fex)
            {
                s = String.Format("Fault Response: {0} {1}",
                                  fex.FaultCode, fex.FaultString);
            }
            catch (WebException webEx)
            {
                s = String.Format("WebException: {0}", webEx.Message);
                if (webEx.Response != null)
                    webEx.Response.Close();
            }
            catch (Exception excep)
            {
                s = String.Format("Exception: {0}", excep.Message);
            }
            richTextBox1.Text.Insert(0, s);
            cmdValidate.Enabled = true;
        }
        private void AppendSuccess(string result)
        {
           // string s = String.Format("State {0} = {1}", stateNum, stateName);
              try
            {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            XmlNodeList xnList = xml.SelectNodes("/params/param/value/array");
            prgBar.Value = 20;
            foreach (XmlNode xn in xnList)
            {

                XmlDocument innerxml = new XmlDocument();
                innerxml.LoadXml(xn.InnerXml);
                XmlNodeList innerxmlList = innerxml.SelectNodes("/data/value/string");
                string name= innerxmlList.Item(0).InnerText;
                string value =innerxmlList.Item(1).InnerText;
                returndata.Add(name, value);
                //richTextBox1.Text = xn.InnerText;
                Console.WriteLine(xn.InnerText);
            }
            prgBar.Value = 80;
            int fehlercode = 999;
            if (returndata.ContainsKey("ErrorCode"))
            {
                try
                {
                    fehlercode = Int32.Parse(returndata["ErrorCode"]);
                    updateStateService(fehlercode);
                    IError ErrorFinder = new IError();
                    if (ErrorFinder.errorCodes.ContainsKey(fehlercode))
                    {
                        stbarlblStatus.Text = ErrorFinder.errorCodes[fehlercode];
                        if (fehlercode != 200)
                        {
                            MessageBox.Show(ErrorFinder.errorCodes[fehlercode],
                                "Die Prüfung hat einen Fehler verursacht!"                                
                                , MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
                catch (FormatException e)
                {
                    cmdValidate.Enabled = true;
                    Console.WriteLine(e.Message);
                }
                
            }
            String retVal = "--------- Daten Ausgabe ---------- ";
            retVal += Environment.NewLine;
            foreach (var data in returndata)
            {
                retVal += String.Format("{0}:\t{1}", data.Key, data.Value);
                retVal += Environment.NewLine; 
            }
            retVal += "---------------------------------- ";
            richTextBox1.Text = retVal;
            }
              catch (Exception excep)
              {
                  cmdValidate.Enabled = true;
                  String s = String.Format("Exception: {0}", excep.Message);
                  richTextBox1.Text.Insert(0, s);
              }

              prgBar.Value = 100;
              cmdValidate.Enabled = true;
            //richTextBox1.Text.Insert(0, result);
        }
        static void GetVaildateIDCallback(IAsyncResult result)
        {
            
            XmlRpcAsyncResult clientResult = (XmlRpcAsyncResult)result;
            IntEvatrRPC uist = (IntEvatrRPC)clientResult.ClientProtocol;
            IntEvatrRPCAsyncState asyncState = (IntEvatrRPCAsyncState)result.AsyncState;
            try
            {
                string s = uist.EndVaildateID(result);
                asyncState.theForm.Invoke(new AppendSuccessDelegate(
                  asyncState.theForm.AppendSuccess), s);
                
            }
            catch (Exception ex)
            {
                asyncState.theForm.Invoke(new AppendExceptionDelegate(
                  asyncState.theForm.AppendException), ex);
            }
        }

        void updateStateService(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 200:
                case 218:
                case 219:
                    lblStatus.Text = "Gültig!";
                    lblStatus.ForeColor = System.Drawing.Color.White; 
                    lblStatus.BackColor = System.Drawing.Color.Green;
                break;
                default:
                  lblStatus.Text="Ungültig!";
                  lblStatus.ForeColor = System.Drawing.Color.Black;
                  lblStatus.BackColor = System.Drawing.Color.Red;
                break;
            }
            
            
            
        }



        private void countIEPull_Tick(object sender, EventArgs e)
        {
          
        }

        private List<string> getIEURLS()
        {
            //https://evatr.bff-online.de/eVatR/?eigene_nr=888888&abfrage_land=IE&abfrage_nr=456454646
            List<string> retVal = new List<string>();
            SHDocVw.ShellWindows SWs = new SHDocVw.ShellWindowsClass();

            foreach (SHDocVw.InternetExplorer IE in SWs)
            {
                // Verarbeiten überspringen
                if (!IE.LocationURL.Contains("bff-online.de"))
                {
                    continue; 
                }
                Uri myUri = new Uri(IE.LocationURL);
                if (!HttpUtility.ParseQueryString(myUri.Query).HasKeys())
                {
                    continue;
                }
                Console.WriteLine(IE.LocationURL);
                retVal.Add(IE.LocationURL);
                NameValueCollection collection = HttpUtility.ParseQueryString(myUri.Query);
                if (collection["abfrage_land"] == null || collection["abfrage_nr"] == null)
                {
                    continue;
                }
                string ustId_2 = collection["abfrage_land"] + collection["abfrage_nr"];
               retVal.Add( ustId_2);
                Console.ReadLine();
            }
            return retVal;
        }

        private void tsButtonIEExplTrack_ButtonClick(object sender, EventArgs e)
        {
            String retvalMulti = "";
            foreach (string x in getIEURLS())
            {
                retvalMulti += x;
                retvalMulti += Environment.NewLine;
            }
            MessageBox.Show(retvalMulti);
        }

    }
   
    class IntEvatrRPCAsyncState
    {
        public IntEvatrRPCAsyncState(String UstId_1, String UstId_2, String Firmenname, String Ort, String PLZ, String Strasse, String Druck, Form1 TheForm)
        {
            ustId_1 = UstId_1;
            ustId_2 = UstId_2;
            firmenname = Firmenname;
            ort = Ort;
            pLZ = PLZ;
            strasse = Strasse;
            druck = Druck;

            theForm = TheForm;
        }
        public String ustId_1; 
        public String ustId_2;
        public String firmenname;
        public String ort;
        public String pLZ;
        public String strasse;
        public String druck;
        public Form1 theForm;
    }
}
