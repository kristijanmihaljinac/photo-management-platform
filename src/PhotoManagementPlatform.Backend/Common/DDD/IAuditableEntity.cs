﻿namespace Common.DDD;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; set; }

    string? CreatedBy { get; set; }

    DateTime? ModifiedOnUtc { get; set; }

    string? ModifiedBy { get; set; }

    bool Active { get; set; }
}

