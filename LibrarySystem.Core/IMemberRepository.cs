using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllAsync();
    Task AddAsync(Member member);

    Task UpdateAsync(Member member);
}