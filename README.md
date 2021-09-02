# D2XXHelper
FTDI的D2XX帮助类 可通过该dll与FT232H等设备通讯。

<p>基于.net standard2.0开发。方便跨平台使用</p>
<p>原理：判断系统环境(win32、win64、linux)通过dllimport方法调用对应的dll(ftd2xx.dll、libftd2xx.so)中的方法实现usb转串口的设备的驱动</p>
<p>项目中集成了windows下的2.12.36.4版本dll。Linux平台需要自己去官网( https://ftdichip.com/drivers/d2xx-drivers/ )下载对应平台的libftd2xx.so文件放在dll同级目录</p>
<p>安装:Install-Package D2XXHelper -Version 0.3.1</p><br />
<p>停止更新.移步至此:<a href="https://github.com/KoKoHomask/FTD2XXHelper">FTD2XXHelper</a>实现方式更优雅,功能更全</p>

