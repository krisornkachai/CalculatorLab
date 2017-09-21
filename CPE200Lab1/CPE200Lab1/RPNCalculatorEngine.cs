using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
         
            if (str == null || str == "")
            {
                return "E";
            }
         
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result=null;
            string firstOperand=null, secondOperand=null;
          
            foreach (string token in parts)
            {
                bool x = isOperand(result) && isOperator(result);
                bool y = isOperand(result);
                bool z = isOperator(result);
                if (token=="++")
                { return "E"; }

                    if (isOperand(token))
                {
                    if (token.First() =='+')
                    {
                        return "E";

                    }
                  
                    rpnStack.Push(token);
                  
                }
                else if (isOperator(token))
                {    
                    if (rpnStack.Count <= 1) { return "E"; }
                    //FIXME, what if there is only one left in stack?
                    secondOperand = rpnStack.Pop();

                    firstOperand = rpnStack.Pop();
                   
                  
                    result = calculate(token, firstOperand, secondOperand, 6);
                  
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
               // else if(!isOperator(token) && !isOperand(token)) { return "E"; }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            //if (rpnStack.Count != 1 || !isNumber(result)) { return "E"; }
            if (rpnStack.Count != 1 ) { return "E"; }
            result = rpnStack.Pop();
           
            //if (y) { return "E"; }
            //  if (result == null) { return "E"; }
            return result;
        }
    }
}
