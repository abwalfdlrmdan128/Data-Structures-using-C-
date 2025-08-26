using System;
using System.Collections.Generic;
using System.Text;

namespace exp_evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix = "2+6*8";
            
            string postfix =convert(infix);

            Console.WriteLine("Infix expression is:\n"+ infix);
            Console.WriteLine("Postfix expression is: \n"+ postfix);
            Console.WriteLine("Evaluated expression is:\n"+ evaluate(postfix));
            Console.ReadLine();
        }
        
        //char stack
        static char[] stack=new char [25];
        static int top = -1;
        static void push(char item)
        {
            stack[++top] = item;
        }
        static char pop()
        {
            return stack[top--];
        }
        //returns precedence of operators
        static int precedence(char symbol)
        {
            switch (symbol)
            {
                case '+':
                    return 2;
                case '-':
                    return 2;
                    
                case '*':
                    return 3;
                case '/':
                    return 3;
                    
                case '^':
                    return 4;
                
                case '#':
                    return 1;
                default:
                    return 0 ;
            }
        }
        //check whether the symbol is operator?
       
        
        
        static int isOperator(char symbol)
        {

            switch (symbol)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                case ')':
                    return 1;
                    
                default:
                    return 0;
            }
        }

        //converts infix expression to postfix
        static string  convert(string infix)
        {
            char[] postfix = new char[25];
            int i,  j = 0;
            char symbol;
            stack[++top] = '#';

            for (i = 0; i < infix.Length; i++)
            {
                symbol = infix[i];

                if (isOperator(symbol) == 0) 
                {
                    postfix[j] = symbol;
                    j++;
                }
                else
                {
                    if (symbol == '(')
                    {
                        push(symbol);
                    }
                    else
                    {
                        if (symbol == ')')
                        {

                            while (stack[top] != '(')
                            {
                                postfix[j] = pop();
                                j++;
                            }

                            pop();   //pop out (. 
                        }
                        else
                                {
                            if (precedence(symbol) > precedence(stack[top]))
                            {
                                push(symbol);
                            }
                            else
                            {

                                while (precedence(symbol) <= precedence(stack[top]))
                                {
                                    postfix[j] = pop();
                                    j++;
                                }

                                push(symbol);
                            }
                        }
                    }
                }
            }

            while (stack[top] != '#')
            {
                postfix[j] = pop();
                j++;
            }

            postfix[j] = '\0';  //null terminate stringf. 
            string postfixx = new string(postfix);
            return postfixx;
        }

        //int stack
        static int[] stack_int=new int [25];
        static int top_int = -1;

        static void push_int(int item)
        {
            stack_int[++top_int] = item;
        }

        static char pop_int()
        {
            return (char)stack_int[top_int--];
        }

        //evaluates postfix e/xpression
        static int evaluate(string postfix)
        {

            char ch;
            int i = 0, operand1, operand2;

            while ((ch = postfix[i++]) != '\0')
            {

                if (Char.IsDigit(ch))
                {
                    push_int(ch - '0');  // Push the operand 
                }
                else
                {
                    //Operator,pop two  operands 
                    operand2 = pop_int();
                    operand1 = pop_int();

                    switch (ch)
                    {
                        case '+':
                            push_int(operand1 + operand2);
                            break;
                        case '-':
                            push_int(operand1 - operand2);
                            break;
                        case '*':
                            push_int(operand1 * operand2);
                            break;
                        case '/':
                            push_int(operand1 / operand2);
                            break;
                    }
                }
            }

            return stack_int[top_int];
        }

       
    }
}
    
