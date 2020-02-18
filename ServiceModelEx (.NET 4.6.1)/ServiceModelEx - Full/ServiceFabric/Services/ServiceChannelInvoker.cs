// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

using ServiceModelEx.ServiceFabric.Services.Remoting;

namespace ServiceModelEx.ServiceFabric.Services
{
   internal class ServiceChannelInvoker<I> where I : class
   {
      public I Install(ChannelFactory<I> factory)
      {
         ChannelInvoker invoker = new ChannelInvoker(typeof(I),factory);
         return invoker.GetTransparentProxy() as I;
      }
      class ChannelInvoker : ChannelInvokerBase<I>
      {
         public ChannelInvoker(Type classToProxy,ChannelFactory<I> factory) : base(classToProxy,factory)
         {}
      }
   }
}
