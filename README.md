# WebDAVSharpCore

A c# WebDAV Server and Client, support netframework and netcore app.

# Reference

- https://github.com/WebDAVSharp/WebDAVSharp.Server
- https://github.com/yar229/WebDavMailRuCloud
- https://github.com/Winterleaf/Winterleaf-WebDavSharp.SQLExample


# Projects

NetFramework
  - WebDAVSharp.Server       : webdav server lib for netframework 4.5
  - WebDAVSharp.Service      : console webdav service
  - WebDAVSharp.Client       : console webdav client

NetCore
  - WebDAVSharp.ServerV2     : webdav server lib for netcore app 2.0
  - WebDAVSharp.ServerV3     : webdav server lib for netcore app 3.0(developing)
  - WebDAVSharp.Site         : aspnetcore site for webdav(developing)



# Tasks
- [x] All-in-one solution
  - [x] WebDAVSharp.Server   : webdav server lib for netfx
  - [x] WebDAVSharp.Service  : console service
  - [x] WebDAVSharp.Client   : console client
  - [x] WebDAVSharp.ServerV2 : webdav server lib for netcoreapp 2
  - [x] WebDAVSharp.ServerV3 : webdav server lib for netcoreapp 3
- [x] Modify project WebDAVSharp.Service
  - [x] Run suceess.
  - [x] Set port and root path.
- [x] RaiDrive client to link to server
  - [x] Success: http://localhost:8880, using windows username and password.
- [x] Modify project WebDAVSharp.Client
  - [x] Run success.
  - [x] Support user, password, domain parameters
  - [x] Create WebDavClient class
- [ ] Create project WebDAVSharp.ServerV3
  - [x] Transfer to supporting netcore app v3.1
  - [x] Comile success
  - [ ] Change Log to serilog(Microsoft.Extensions.Logging)
  - [ ] Change user to db store, not windows users.
- [ ] Create project WebDAVSharp.Site
  - [ ] Login
  - [ ] Dir
  - [ ] Download
  - [ ] Upload
  - [ ] Rename
  - [ ] Move
  - [ ] Lock/Unlock
 


