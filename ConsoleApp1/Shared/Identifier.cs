using System;
using Newtonsoft.Json;

namespace ConsoleApp1.Shared;

public class Identifier : EntityId
{
    
    
    [JsonConstructor]
    public Identifier(Guid value) : base(value)
    {
    }

    public Identifier(String value) : base(value)
    {
    }

    override
        protected Object createFromString(String text)
    {
        return new Guid(text);
    }

    override
        public String AsString()
    {
        Guid obj = (Guid)base.ObjValue;
        return obj.ToString();
    }

    public Guid AsGuid()
    {
        return (Guid)base.ObjValue;
    }
}