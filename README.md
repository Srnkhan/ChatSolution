"# ChatSolution" 

Migration'lar yapılmıştır.MsSql veya MySql de proje çalışmaktadır.
MsSql üzerinden çalışılacak ise ChatDb içinde yer alan Data folderında MySql migration dosyası , 
MySql üzerinden çalışılacak ise ChatDb içinde yer alan Data folderında MsSql migration dosyası exclude edilerek 
update-database -verbose ile istenilen db de tablolar oluşturulur.

Proje .Net Core 3.1 ve bu framework ile uyumlu frameworkler üzerinden çalışılmıştır.
