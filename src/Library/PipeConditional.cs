using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        private IFilterConditional filter;
        private IPipe truePipe;
        private IPipe falsePipe;

        public PipeConditional(IFilterConditional filter, IPipe truePipe, IPipe falsePipe)
        {
            this.filter = filter;
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
        }

        public IPicture Send(IPicture picture)
        {
            picture = filter.Filter(picture);
            if (filter.Result)
            {
                return truePipe.Send(picture);
            }
            else
            {
                return falsePipe.Send(picture);
            }
        }
    }
}
