using System.Collections.Generic;

namespace SpecFlow.GenericContainer.SpecFlowPlugin.Tests
{
    public class Calculator : ICalculator
    {
        private readonly Stack<int> _operands = new Stack<int>();

        public Calculator()
        {

        }

        public void Enter(int operand)
        {
            _operands.Push(operand);
        }

        public void Add()
        {
            _operands.Push(_operands.Pop() + _operands.Pop());
        }

        public int Result => _operands.Peek();
    }
}