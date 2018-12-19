﻿namespace SpecFlow.GenericContainer.SpecFlowPlugin.Tests
{
    public interface ICalculator
    {
        void Enter(int operand);
        void Add();
        int Result { get; }
    }
}
