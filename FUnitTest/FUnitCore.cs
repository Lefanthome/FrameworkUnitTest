using System;
using System.Runtime.CompilerServices;

namespace FUnitTest
{
    enum MsgType
    {
        Ok,
        Failed
    }

    public class FUnitCore
    {
        public static int nbError = 0;

        public static void Excecute(ClassInfo classInfo)
        {
            Console.WriteLine($"Start Unit Test");

            int countTest = 0;
            var intance = Activator.CreateInstance(classInfo.Type);

            //Get List Method by Class
            foreach (var method in classInfo.MethodsInfo)
            {
                countTest++;
                try
                {
                    method.Invoke(intance, null);
                }
                catch (Exception ex)
                {
                    Message(MsgType.Failed, $"Failed: Method Name: {method.Name} - message: {ex.Message}");
                }

            }
            //PRINT
            Console.WriteLine($"{nbError} test(s) en erreur sur {countTest} tests executes");
        }

        public static void IsTrue(bool condition, [CallerMemberName] string member = "")
        {
            if (condition)
                Ok($"Method Name: {member} - condition");
            else
                Fail($"Method Name: {member} - condition");
        }

        public static void IsEquality(bool expectedValue, bool resultValue, [CallerMemberName] string member = "")
        {
            if (expectedValue == resultValue)
                Ok($"Method Name: {member} - Expected : {expectedValue} - Result: {resultValue}");
            else
                Fail($"Method Name: {member} - Expected : {expectedValue} - Result: {resultValue}");
        }

        #region private methods
        static void Message(MsgType msgType, string message)
        {
            switch (msgType)
            {
                case MsgType.Ok:
                    Ok("Ok: " + message);
                    break;
                case MsgType.Failed:
                    Fail("Failed: " + message);
                    break;
            }
        }

        static void Ok(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Fail(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            nbError++;
        }
        #endregion
    }
}
