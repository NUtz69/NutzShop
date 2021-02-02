using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NutzShop.WebUI.Tests.Mocks
{
    // Base
    public class MockHttpContext : HttpContextBase
    {
        // Var
        private MockRequest request;
        private MockRepsonse response;
        private HttpCookieCollection cookies;

        // Constructors
        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.request = new MockRequest(cookies);
            this.response = new MockRepsonse(cookies);
        }

        // Override
        public override HttpRequestBase Request
        {
            get
            {
                return request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return response;
            }
        }
    }

    /* Read & write cookies */

    // Cookies collection - Repsonse
    public class MockRepsonse : HttpResponseBase
    {
        // Private Cookies collection
        private readonly HttpCookieCollection cookies;

        // Constructors
        public MockRepsonse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        // Override
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }

    // Cookies collection - Request
    public class MockRequest : HttpRequestBase
    {
        // Private Cookies collection
        private readonly HttpCookieCollection cookies;

        // Constructors
        public MockRequest(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        // Override
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
}
