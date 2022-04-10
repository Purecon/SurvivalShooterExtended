# IF3210-2022-Unity-40

Dev vs Zombie
Survival Shooter Extended Edition

## Deskripsi Aplikasi
Aplikasi ini adalah pengembangan survival shooter game dari Unity Learn dengan penambahan fitur Atribut Player, Orbs, tambahan Mobs, Game Mode Zen, Wave, dan First Person, Weapon Upgrade, Local Scoreboard, Main Menu, dan Game Over.
## Cara Kerja
 - Attribute Player: 
 - Orbs: 
 - Additional Mobs : Additional Mobs dibuat dengan membuat prefab mob baru yang kemudian ditambahkan ke dalam enemyFactory.
 - Zen Mode : Dibuat dengan menambahkan timer pada game.
 - Wave Mode : Dibuat sesuai spesifikasi, untuk setiap wave aplikasi akan mengecek apakah semua enemy sudah mati kemudian memulai wave berikutnya. untuk enemy pool pada 3 wave pertama menggunakan mobs bawaan dari survival shooter, 3 wave berikutnya ditambah dengan mob skeleton, 3 wave berikutnya ditambah dengan bomber, dan untuk seluruh wave setelahnya menggunakan semua mobs yang ada. Jika sudah mencapai maksimum wave akan ditampilkan pesan bahwa player menang.
 - Weapon Upgrade: untuk diagonal weapon dibuat dengan menambahkan jumlah raycast yang dilakukan setiap menembak dan juga jumlah garis yang dirender. untuk faster weapon dibuat dengan memperkecil nilai Time between bullets. Untuk wavemode weapon upgrade dapat dilakukan setiap interval waktu tertentu yang dapat menjadi semakin besar semakin lama waktu yang berjalan (contoh weapon upgrade pertama 20 detik, kedua 40 detik, dst) dan untuk wave mode dapat dilakukan setelah menyelesaikan wave yang terdapat boss.
 - Local Scoreboard: Pada akhir setiap permainan score akan disimpan dan 4 skor tertinggi untuk setiap mode dapat dilihat pada menu scoreboard.
 - Main Menu : Main menu dibuat dengan 4 menu yaitu play, settings, leaderboard, dan quit. pada menu play dapat memilih mode permainan kemudian memulai permainan. Pada menu settings dapat mengganti nama player, pada menu leaderboard akan menampilkan leaderboard mode wave dan zen, dan quit untuk keluar dari game.
 - Game Over: tampilan game over akan muncul ketika player mati dan akan menampilkan skor atau waktu akhir dan memiliki tombol untuk memulai game dengan mode yang sama atau kembali ke main menu.
 - First Person Mode:
 - Object Pooling


## Screenshot

## Pembagian Kerja
 - David Owen(13519169) : Attribute Player, Orbs
 - Muhammad Furqon (13519184) : Additional Mobs, Zen Mode, Local Scoreboard, Main Menu, Object Pooling, First Person Mode
 - Ahmad Saladin (13519187) : Weapon Upgrade, Wave Mode, Game Over


