using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace UstIdValidator
{
    [XmlRpcUrl("https://evatr.bff-online.de/")]
    public interface IntEvatrRPC : IXmlRpcProxy
    {
        [XmlRpcMethod("evatrRPC")]
        string VaildateID(String UstId_1, String UstId_2, String Firmenname, String Ort, String PLZ, String Strasse, String Druck);

        [XmlRpcBegin("evatrRPC")]
        IAsyncResult BeginVaildateID(String UstId_1, String UstId_2, String Firmenname, String Ort, String PLZ, String Strasse, String Druck, AsyncCallback acb,
    object state);

        [XmlRpcEnd]
        string EndVaildateID(IAsyncResult asr);
    }
}
