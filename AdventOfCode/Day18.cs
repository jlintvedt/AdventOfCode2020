using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/18
    /// </summary>
    public class Day18
    {
        public class OperationOrder
        {
            readonly Element Equation;
            readonly bool AddBeforeMultiply;

            public OperationOrder(string input, bool addBeforeMultiply = false)
            {
                var inputEquation = $"({input})".ToCharArray();
                var index = 0;
                AddBeforeMultiply = addBeforeMultiply;

                Equation = ParseEquationRec(inputEquation, ref index);
            }

            #region Parse
            private Element ParseEquationRec(char[] input, ref int index)
            {
                Element current = Element.NewElement(GetNextNonWhitespaceChar(input, ref index));

                if (current.Type == Type.Equation)
                {
                    while (true)
                    {
                        var next = ParseEquationRec(input, ref index);
                        if (next.Type == Type.EndEquation)
                        {
                            break;
                        }

                        current.SubEquation.AddLast(next);
                    }
                }

                return current;
            }

            private char GetNextNonWhitespaceChar(char[] input, ref int index)
            {
                char c;
                do
                {
                    c = input[index++];
                } while (c == ' ');
                
                return c;
            }
            #endregion

            #region Solve
            public long Solve()
            {
                SolveEquation(Equation);
                return Equation.Value;
            }


            private void SolveEquation(Element equation)
            {
                LinkedListNode<Element> currentNode;
                // Puzzle 1
                if (!AddBeforeMultiply)
                {
                    currentNode = GetFirstNode(equation.SubEquation);
                    while (HasMoreOperations(currentNode))
                    {
                        PerformOperation(currentNode);
                        equation.SubEquation.Remove(currentNode.Next);
                        equation.SubEquation.Remove(currentNode.Next);
                    }
                } 
                // Puzzle 2
                else
                {
                    // Perform add
                    currentNode = GetFirstNode(equation.SubEquation);
                    while (HasMoreOperations(currentNode))
                    {
                        if (PerformOperation(currentNode, skipMultiply: true))
                        {
                            equation.SubEquation.Remove(currentNode.Next);
                            equation.SubEquation.Remove(currentNode.Next);
                        } 
                        else
                        {
                            // If operation was not performed: skip to next operation
                            currentNode = currentNode.Next.Next;
                        }
                    }
                    
                    // Perform multiply
                    currentNode = GetFirstNode(equation.SubEquation);
                    while (HasMoreOperations(currentNode))
                    {
                        PerformOperation(currentNode);
                        equation.SubEquation.Remove(currentNode.Next);
                        equation.SubEquation.Remove(currentNode.Next);
                    } 
                }
                

                equation.SetNumber(currentNode.Value.Value);
            }

            /// <summary>
            /// Performns the next operation on the current node's value and the next number node's value.
            /// </summary>
            /// <param name="currentNode">The first number node of the operation. The result is stored in this node.</param>
            /// <param name="skipMultiply">Indicates if multiplication operations should be skipped.</param>
            /// <returns>Indicates if the operation was performed.</returns>
            private bool PerformOperation(LinkedListNode<Element> currentNode, bool skipMultiply=false)
            {
                var operation = GetNextOperation(currentNode);
                var otherNode = GetNextValue(currentNode);

                if (operation.Type == Type.Add)
                {
                    currentNode.Value.Value += otherNode.Value;
                    return true;
                }
                else if (!skipMultiply && operation.Type == Type.Multiply)
                {
                    currentNode.Value.Value *= otherNode.Value;
                    return true;
                }

                return false;
            }

            private Element GetNextOperation(LinkedListNode<Element> currentNode)
            {
                return currentNode.Next.Value;
            }

            private Element GetNextValue(LinkedListNode<Element> currentNode)
            {
                var next = currentNode.Next.Next.Value;
                if (next.Type == Type.Equation)
                {
                    SolveEquation(next);
                }
                return next;
            }

            private LinkedListNode<Element> GetFirstNode(LinkedList<Element> list)
            {
                var first = list.First;
                if (first.Value.Type == Type.Equation)
                {
                    SolveEquation(first.Value);
                }
                return first;
            }

            private bool HasMoreOperations(LinkedListNode<Element> currentNode)
            {
                if (currentNode.Next != null)
                {
                    return true;
                }

                return false;
            }
            #endregion

            #region Element
            private enum Type {
                Number,
                Add,
                Multiply,
                Equation,
                EndEquation
            }

            private class Element
            {
                public Type Type;
                public long Value;
                public LinkedList<Element> SubEquation;

                public static Element NewElement(char symbol)
                {
                    switch (symbol)
                    {
                        case '+':
                            return new Element(Type.Add);
                        case '*':
                            return new Element(Type.Multiply);
                        case '(':
                            return new Element(Type.Equation);
                        case ')':
                            return new Element(Type.EndEquation);
                        default:
                            return new Element(Type.Number, symbol - '0');
                    }
                }
                
                public Element(Type type, int value = 0)
                {
                    Type = type;
                    Value = value;

                    if (Type == Type.Equation)
                    {
                        SubEquation = new LinkedList<Element>();
                    }
                }

                public void SetNumber(long number)
                {
                    Value = number;
                    Type = Type.Number;
                    SubEquation = null;
                }

                public override string ToString()
                {
                    return Type switch
                    {
                        Type.Number => $"Number: {Value}",
                        Type.Add => "Add",
                        Type.Multiply => "Multiply",
                        Type.Equation => $"Equation. Elements[{SubEquation.Count}]",
                        Type.EndEquation => "Equation End",
                        _ => throw new Exception("Unkown element"),
                    };
                }
            }
            #endregion
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            long sum = 0;
            foreach (var exp in input.Split(Environment.NewLine))
            {
                sum += (new OperationOrder(exp).Solve());
            }

            return sum.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            long sum = 0;
            foreach (var exp in input.Split(Environment.NewLine))
            {
                sum += (new OperationOrder(exp, addBeforeMultiply: true).Solve());
            }

            return sum.ToString();
        }
    }
}
