using CreateExam.Core.Enums;
using System;

namespace CreateExam.Core.Entities.Interfaces
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; }
        DateTime? UpdateDate { get; }
        DateTime? DeleteDate { get; }
        Status Status { get; }
    }
}