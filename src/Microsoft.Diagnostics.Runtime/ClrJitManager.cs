// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Runtime.AbstractDac;
using Microsoft.Diagnostics.Runtime.Interfaces;

namespace Microsoft.Diagnostics.Runtime
{
    public sealed class ClrJitManager : IClrJitManager
    {
        private readonly IAbstractNativeHeapProvider? _helpers;

        public ClrRuntime Runtime { get; }
        IClrRuntime IClrJitManager.Runtime => Runtime;

        public ulong Address { get; }

        public CodeHeapKind Kind { get; }

        internal ClrJitManager(ClrRuntime runtime, in JitManagerInfo info, IAbstractNativeHeapProvider? helpers)
        {
            Runtime = runtime;
            Address = info.Address;
            Kind = info.Kind;
            _helpers = helpers;
        }

        public IEnumerable<ClrNativeHeapInfo> EnumerateNativeHeaps() => _helpers?.EnumerateJitManagerHeaps(Address) ?? Enumerable.Empty<ClrNativeHeapInfo>();
    }
}