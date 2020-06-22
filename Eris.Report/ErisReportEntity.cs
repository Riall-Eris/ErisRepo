using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Eris.Reporter
{
    public class ErisReportEntity
    {
        
    }
}

public class ERParameter
{
    public ERParameter() { }
    public string ParameterName { get; set; }
    public string ParameterValue { get; set; }
}

public enum DataMode
{
    AloneData,
    MasterDetail
}