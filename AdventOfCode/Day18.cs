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
            Element Equation;

            public OperationOrder(string input)
            {
                var inputEquation = $"( {input} )".Split(' ');
                var index = 0;

                Equation = ParseEquationRec(inputEquation, ref index);
            }

            private Element ParseEquationRec(string[] input, ref int index)
            {
                Element current = Element.NewElement(input[index++]);

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

            public long Solve()
            {
                SolveEquation(Equation);
                return Equation.Value;
            }


            private void SolveEquation(Element equation)
            {
                var currentNode = GetFirstNode(equation.SubEquation);
                do
                {
                    PerformOperation(currentNode);
                    equation.SubEquation.Remove(currentNode.Next);
                    equation.SubEquation.Remove(currentNode.Next);
                } while (HasMoreOperations(currentNode));

                equation.SetNumber(currentNode.Value.Value);
            }

            private bool PerformOperation(LinkedListNode<Element> currentNode)
            {
                var operation = GetNextOperation(currentNode);
                var otherNode = GetNextValue(currentNode);

                if (operation.Type == Type.Add)
                {
                    currentNode.Value.Value += otherNode.Value;
                    return true;
                }
                else if (operation.Type == Type.Multiply)
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

                public static Element NewElement(string symbol)
                {
                    switch (symbol)
                    {
                        case "+":
                            return new Element(Type.Add);
                        case "*":
                            return new Element(Type.Multiply);
                        case "(":
                            return new Element(Type.Equation);
                        case ")":
                            return new Element(Type.EndEquation);
                        default:
                            return new Element(Type.Number, int.Parse(symbol));
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
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            input = input.Replace("(", "( ");
            input = input.Replace(")", " )");

            var expressions = input.Split(Environment.NewLine);

            long sum = 0;
            foreach (var exp in expressions)
            {
                var oo = new OperationOrder(exp);
                sum += oo.Solve();
            }

            return sum.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            input = input.Replace("(", "( ");
            input = input.Replace(")", " )");

            var oo = new OperationOrder(input);

            return input + "_Puzzle2";
        }
    }
}
