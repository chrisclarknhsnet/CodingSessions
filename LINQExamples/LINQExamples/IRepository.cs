using System;

namespace LINQExamples
{
    public interface IRepository
    {
        DateTime? Get_WhenRegistered(string email);
    }
}