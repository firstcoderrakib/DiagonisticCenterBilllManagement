using System;
using DiagonisticCenterBilllManagement.DAL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.BLL
{
    public class TestManager:TestGatway
    {
        TestGatway testGeteay = new TestGatway();

        public override int AddTest(Tests test)
        {
            if (IsTestNameExist(test.tName))
            {
                throw new Exception("Test name is already exist");
            }
            if (test.tName == null || test.tName == "")
            {
                throw new Exception("Please write test name");
            }

            return base.AddTest(test);
        }
        public bool IsTestNameExist(string tName)
        {
            bool isTestNameExist = false;
            Tests testName = GetTestByName(tName);
            if (testName != null)
            {
                isTestNameExist = true;
            }
            return isTestNameExist;

        }
    }
}