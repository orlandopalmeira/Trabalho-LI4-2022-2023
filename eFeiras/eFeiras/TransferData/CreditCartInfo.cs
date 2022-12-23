using System.Runtime.CompilerServices;

namespace eFeiras.TransferData
{
    public class CreditCartInfo
    {
        private static string? number = null;
        private static string? cvv = null;
        private static string? validade = null;
        private static string? titular = null;

        public static void setData(string number, string cvv, string validade, string titular)
        {
            CreditCartInfo.number = number;
            CreditCartInfo.cvv = cvv;
            CreditCartInfo.validade = validade;
            CreditCartInfo.titular = titular;
        }

        public static string getNumber()
        {
            return CreditCartInfo.number;
        }

        public static string getCVV()
        {
            return CreditCartInfo.cvv;
        }

        public static string getValidade()
        {
            return CreditCartInfo.validade;
        }

        public static string getTitular()
        {
            return CreditCartInfo.titular;
        }

        public static void clear()
        {
            number = cvv = validade = titular = null;
        }

    }
}
