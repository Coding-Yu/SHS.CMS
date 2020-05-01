using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.AutoMapper
{
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //if (operation.Parameters == null)
            //    operation.Parameters = new List<OpenApiParameter>();

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Name = "token",
            //    In = ParameterLocation.Header,
            //    Description = "token",
            //    Required = true,
            //});
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            var attrs = context.ApiDescription.CustomAttributes();//.GetActionAttributes();
            foreach (var attr in attrs)
            {
                // 如果 Attribute 是我们自定义的验证过滤器
                if (attr.GetType() == typeof(AddAuthTokenHeaderParameter))
                {
                    operation.Parameters.Add(new OpenApiParameter()
                    {
                        Name = "AuthToken",
                        In = ParameterLocation.Header,
                        Required = true
                    });
                }
            }
        }
    }
}
