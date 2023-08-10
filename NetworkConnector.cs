using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//네트워크 접근 권한
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace SkillExcel
{
    public class NetworkConnector
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string IpLocalName;
            public string IpRemoteName;
            public string IpComment;
            public string IpProvider;
        }

        
        //public NETRESOURCE NetworkResource = new NETRESOURCE();
        
        //API 함수 선언
        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetUseConnection(
            IntPtr hwnOwner,
            [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE IpNetResource,
            //string IpPassword,
            //string IpUserID,
            uint dwFlags,
            StringBuilder IpAccessName,
            ref int IpBufferSize,
            out uint IpResult);

        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = CharSet.Auto)]
        public static extern int WNetCancelConnection2A(string IpName, int dwFlags, int fForce);


        /*
        //public int TryConnectionNetwork(string remotePath, string userID, string pwd)
        public int TryConnectionNetwork(string remotePath)
        {
            int capacity = 1028;
            uint resultFlags = 0;
            uint flags = 0;
            StringBuilder sb = new StringBuilder();

            NetworkResource.dwType = 1; //공유디스크
            NetworkResource.IpLocalName = null; // 로컬디스크 지정X
            NetworkResource.IpRemoteName = remotePath;
            NetworkResource.IpProvider = null;


            //int result = WNetUseConnection(IntPtr.Zero, ref NetworkResource, pwd, userID, flags, sb, ref capacity, out resultFlags);
            int result = WNetUseConnection(IntPtr.Zero, ref NetworkResource, flags, sb, ref capacity, out resultFlags);
            MessageBox.Show("net connection: " + result.ToString()); //87
            return result;
        }

        public void DisconnectiNetwork()
        {
            WNetCancelConnection2A(NetworkResource.IpRemoteName, 1, 0);
        }
        */

        public int ConnectRemoteServer(string server)
        {
            int capacity = 64;
            uint resultFlags = 0;
            uint flags = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(capacity);
            NETRESOURCE ns = new NETRESOURCE();
            ns.dwType = 1; //공유디스크
            ns.IpLocalName = null; // 로컬디스크 지정X
            ns.IpRemoteName = server;
            ns.IpProvider = null;
            int result = 0;
            if(server == @"\\10.80.251.201\\넥슨네트웍스 퍼블리싱qa2팀\\3. 클로저스\\[클로저스] 스킬 아카이빙 프로그램$")
            {
                result = WNetUseConnection(IntPtr.Zero, ref ns, flags, sb, ref capacity, out resultFlags);
            }
            //MessageBox.Show("Net conncetion: " + result.ToString());

            return result;
        }

        public void CancelRemoteServer(string server)
        {
            WNetCancelConnection2A(server, 1, 0);
        }


        }
}
