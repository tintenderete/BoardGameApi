using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApi
{
    
    class TestRunner
    {
        private string testName;
        private List<string> reports = new List<string>();

        private string txtInit = "Starts: ";
        private string txtFail = "F / ";
        private string txtSuccess = "S / ";
        private string txtHadToBe = ". Had to be: ";
        private string txtButIs = ", But is: ";

        public void RunTest(bool funtionTOTest, string testName)
        {
            this.testName = testName;

            if (!funtionTOTest)
            {
                Console.WriteLine(txtFail + testName);
                
                for (int i = 0; i < reports.Count; i++)
                {
                    Console.WriteLine(this.reports[i]);
                }
            }
            else
            {
                Console.WriteLine(txtSuccess + testName);
            }

            Console.WriteLine(" ");
            this.reports.Clear();
        }

        public void Report<T>(string decription, T hadTobe, T butItIS )
        {

            string report = "  - "+  decription + this.txtHadToBe + hadTobe + this.txtButIs + butItIS ;
            this.reports.Add(report);
            
        }


    }
}
