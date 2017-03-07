using System;
using DiagonisticCenterBilllManagement.DAL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.BLL
{
    public class TestTypeManager:TypeGetway
    {
        TypeGetway typeGeteay = new TypeGetway();

        public override int AddType(Types testType)
        {
            if (IsTypeNameExist(testType.TypeName))
            {
                throw new Exception("Test type name is already exist");
            }
            if (testType.TypeName == null || testType.TypeName == "")
            {
                throw new Exception("Please write type name");
            }
            
            return base.AddType(testType);
        }
        public bool IsTypeNameExist(string typeName)
        {
            bool isTypeNameExist = false;
            Types testType = GetTestTypeByName(typeName);
            if (testType != null)
            {
                isTypeNameExist = true;
            }
            return isTypeNameExist;

        }
        
   }
}