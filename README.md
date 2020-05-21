# WebDAVSharpCore

A c# WebDAV Server and Client, support netframework and netstandard.

# Reference

- https://github.com/WebDAVSharp/WebDAVSharp.Server
- https://github.com/yar229/WebDavMailRuCloud

# Solution

- WebDAVSharp.Server       : webdav server lib for netframework 4.5
- WebDAVSharp.Service      : console webdav service
- WebDAVSharp.Client       : console webdav client
- WebDAVSharp.ServerCore   : webdav server lib for netstandard
- WebDAVSharp.Site         : aspnetcore site for webdav



# Tasks
- [x] Remake solution
  - [x] WebDAVSharp.Server   : lib
  - [x] WebDAVSharp.Service  : console service
  - [x] WebDAVSharp.Client   : console client
- [x] Modify project WebDAVSharp.Service
  - [x] Run suceess.
  - [x] Set port and root path.
- [x] RaiDrive client to link to server
  - [x] Success: http://localhost:8880, windows username and password.
- [x] Modify project WebDAVSharp.Client
  - [x] Run success.
  - [x] Support user, password, domain parameters
  - [x] Create WebDavClient class
- [ ] Create project WebDAVSharp.ServerCore
  - [ ] Transfer to supporting netstandard 2.0
  - [ ] Modify Log service
  - [ ] Comile success
- [ ] Create project WebDAVSharp.Site
  - [ ] Login
  - [ ] Show dir
  - [ ] Download file
  - [ ] Upload file
  - [ ] Lock and unlock file
- [ ] Create project WebDAVBlog
    - [ ] 数据库支持
    - [ ] 全文检索
    - [ ] 用户目录隔离和配额
    - [ ] 上传文档
    - [ ] 预览文档
      - [ ] Office
      - [ ] xmind
      - [ ] markdown
    - [ ] 发布为网页
    - [ ] 云备份