# AI CONTEXT --- TINY PREDATORS

> Konteks proyek dan aturan kerja untuk AI coding assistant. Baca
> dokumen ini sebelum menganalisis, membuat, atau mengubah file proyek.

  Informasi             Detail
  --------------------- -------------------------
  Nama proyek           Tiny Predators
  Platform              PC / Windows
  Genre                 2D Arcade Survival
  Mode                  Single-player
  Engine                Unity 6.6
  Bahasa                C#
  Tim                   3 orang
  Target pengembangan   6 minggu
  Dokumen terkait       `PRD.md`, `WORKFLOW.md`

## 1. Tujuan Dokumen

Dokumen ini memberikan konteks tentang tujuan game, mekanisme, rancangan
arsitektur, konvensi kode, dan batasan ketika AI membantu pengembangan
Tiny Predators.

Dokumen ini berisi rancangan dan pedoman, bukan bukti bahwa seluruh
sistem telah diimplementasikan. Selalu periksa struktur folder, kode,
Scene, Prefab, dan konfigurasi proyek aktual sebelum membuat perubahan.

Urutan acuan: 1. Instruksi eksplisit terbaru dari pengguna atau tim. 2.
Implementasi dan konfigurasi proyek aktual. 3. `PRD.md` untuk kebutuhan
produk. 4. `WORKFLOW.md` untuk proses dan pembagian kerja. 5. Dokumen
ini untuk konteks dan pedoman AI.

Jika terdapat konflik antara dokumen dan implementasi aktual, jelaskan
konflik tersebut sebelum melakukan perubahan berisiko.

## 2. Ringkasan Proyek

**Tiny Predators** adalah game 2D Arcade Survival bertema bawah laut.
Pemain mengendalikan ikan kecil, memangsa ikan yang lebih kecil untuk
memperoleh skor dan bertumbuh, serta menghindari ikan yang lebih besar
karena dapat memangsa pemain.

Game terinspirasi dari mekanisme dasar Feeding Frenzy, tetapi harus
memiliki identitas sendiri melalui desain karakter, visual, lingkungan,
UI, audio, dan penyesuaian mekanisme.

-   Visual: Cartoon 2D.
-   Platform: PC Windows.
-   Mode: single-player.
-   Kontrol utama: WASD.
-   Arena awal: satu arena bawah laut.
-   Mode permainan: Objective Mode dan Endless Mode.

Tujuan versi awal adalah menghasilkan game Windows yang dapat dimainkan
dari Main Menu sampai sesi permainan berakhir, dengan gerakan, sistem
memangsa, pertumbuhan, skor, AI ikan, dua mode, dan UI utama.

## 3. Gameplay dan Aturan Inti

### 3.1 Core Gameplay Loop

1.  Pemain memilih mode dari Main Menu.
2.  Game memulai sesi di arena bawah laut.
3.  Pemain bergerak menggunakan WASD.
4.  Pemain mencari ikan yang lebih kecil.
5.  Pemain memangsa ikan yang memenuhi syarat.
6.  Pemain memperoleh skor dan bertumbuh.
7.  Pemain menghadapi ikan yang sebelumnya terlalu besar atau
    menghindari predator.
8.  Permainan berakhir sesuai aturan mode dan kondisi hidup pemain.

### 3.2 Jenis Entitas

  -----------------------------------------------------------------------
  Entitas                             Peran
  ----------------------------------- -----------------------------------
  Player                              Dikendalikan pemain dan dapat
                                      memangsa ikan yang lebih kecil

  Small Fish                          Ikan kecil, menjadi mangsa awal,
                                      bergerak dengan AI sederhana

  Medium Fish                         Ikan menengah, dapat memangsa ikan
                                      yang lebih kecil

  Predator                            Ikan besar yang dapat mengejar dan
                                      memangsa Player
  -----------------------------------------------------------------------

Nama class, prefab, dan jenis ikan aktual harus mengikuti struktur
proyek yang sudah ada. Jangan membuat duplikasi hanya karena nama
rancangan di dokumen ini.

### 3.3 Aturan Ukuran

Gunakan atribut ukuran gameplay yang eksplisit, misalnya `sizeLevel`
atau `sizeValue`, untuk menentukan hubungan pemangsa dan mangsa.

-   Pemangsa hanya dapat memakan target jika ukuran gameplay pemangsa
    lebih besar.
-   Jika ukurannya sama, tidak terjadi proses memangsa.
-   Jika ukuran pemangsa lebih kecil, ia tidak dapat memakan target.
-   Predator yang lebih besar dapat memangsa Player.
-   Setelah tumbuh, Player dapat memangsa ikan yang sebelumnya terlalu
    besar jika nilai ukurannya sudah memenuhi syarat.

Jangan menggunakan `Transform.localScale` atau ukuran sprite sebagai
satu-satunya dasar aturan makan. Skala visual boleh mengikuti nilai
ukuran gameplay, tetapi aturan gameplay harus memakai data ukuran yang
konsisten.

### 3.4 Skor dan Pertumbuhan

-   Memangsa ikan yang valid menambah skor.
-   Memangsa ikan yang valid meningkatkan ukuran Player.
-   Nilai skor dan pertumbuhan dapat berbeda berdasarkan jenis ikan.
-   Nilai numerik final belum ditetapkan. Jangan mengarang angka sebagai
    keputusan desain.
-   Pastikan satu ikan hanya dihitung satu kali ketika dimangsa.

### 3.5 Mode Permainan

**Objective Mode** - Memiliki target yang harus dicapai. - Target dapat
berupa skor atau ukuran/tingkat pertumbuhan. - Jenis target dan nilainya
masih perlu ditetapkan tim. - Jika target tercapai sebelum Player mati,
hasilnya Victory. - Jika Player mati sebelum target tercapai, hasilnya
Game Over.

**Endless Mode** - Tidak memiliki target kemenangan. - Pemain berusaha
bertahan hidup dan memperoleh skor setinggi mungkin. - Permainan
berakhir ketika Player mati.

Kedua mode sebaiknya menggunakan arena dan mekanisme inti yang sama.
Perbedaan mode dikelola melalui konfigurasi atau status mode, bukan
dengan menggandakan seluruh sistem gameplay.

## 4. Teknologi dan Lingkungan Pengembangan

Informasi yang telah disepakati: - Unity 6.6. - C# untuk scripting. - VS
Code sebagai editor kode. - Git dan GitHub untuk kolaborasi. - Aset
merupakan kombinasi aset gratis dan aset buatan tim.

Sebelum menggunakan API atau package: 1. Periksa versi Unity Editor yang
benar-benar digunakan proyek. 2. Periksa `Packages/manifest.json` dan
konfigurasi terkait. 3. Pastikan API yang disarankan kompatibel. 4.
Jangan menambahkan package eksternal jika fitur bawaan Unity sudah
memadai.

Jangan mengasumsikan versi patch Unity, package, Input System, atau
konfigurasi build jika belum diperiksa.

## 5. Rancangan Arsitektur Sistem

Bagian ini merupakan rancangan tanggung jawab, bukan klaim bahwa semua
script telah tersedia. Periksa implementasi aktual sebelum menambah atau
mengganti file.

  Sistem                       Tanggung jawab
  ---------------------------- --------------------------------------------------------
  Player Controller            Membaca input dan menggerakkan Player
  Player Growth                Mengelola ukuran gameplay dan pertumbuhan
  Player Health / Life State   Mengelola kondisi hidup dan kematian
  Fish AI                      Mengatur perilaku gerak ikan non-pemain
  Fish Data                    Menyimpan konfigurasi ukuran, skor, dan parameter ikan
  Fish Spawner                 Mengatur kemunculan ikan jika spawn dinamis digunakan
  Game Manager                 Mengelola status dan alur sesi
  Score Manager                Mengelola skor sesi
  UI Manager                   Memperbarui UI berdasarkan data dan status game

Nama dan jumlah script boleh disesuaikan. Hindari membuat banyak manager
kecil tanpa alasan.

### 5.1 Prinsip Pemisahan Sistem

-   Player Controller menangani input dan gerakan, bukan seluruh aturan
    game.
-   Sistem gameplay menentukan apakah interaksi makan valid.
-   Fish AI mengatur perilaku gerak, bukan mengelola UI.
-   Sistem skor menjadi sumber data skor yang konsisten.
-   UI menampilkan data dan mengirim permintaan aksi; UI bukan tempat
    utama aturan gameplay.
-   Game Manager mengatur status sesi dan transisi alur permainan.
-   Hindari ketergantungan antarsistem yang tidak diperlukan.

Gunakan referensi Inspector, method publik, C# event, atau UnityEvent
sesuai kebutuhan. Jangan memperkenalkan event bus, dependency injection
framework, atau pola kompleks tanpa alasan jelas.

Hindari pencarian objek global seperti `FindObjectOfType` berulang kali
di dalam `Update()`. Simpan referensi yang diperlukan dan kelola
lifecycle-nya dengan benar.

### 5.2 Status Game

Status konseptual minimum: - Main Menu - Playing - Paused - Victory -
Game Over

Ketika permainan Pause atau berakhir, input gameplay, AI, dan proses
terkait harus berhenti sesuai kebutuhan. Pastikan transisi status tidak
menghasilkan beberapa kondisi akhir sekaligus.

### 5.3 Scene dan Prefab

Rancangan awal: - `MainMenu` untuk menu utama. - `Game` untuk arena dan
gameplay.

Kedua mode dapat menggunakan Scene Game yang sama dengan konfigurasi
mode berbeda. Gunakan Prefab untuk objek berulang seperti ikan. Jangan
membuat Scene atau Prefab tambahan tanpa kebutuhan.

## 6. Struktur Folder yang Disarankan

Struktur berikut adalah rekomendasi, bukan instruksi untuk merombak
proyek. Periksa struktur aktual dan pertahankan konvensi yang sudah
konsisten.

``` text
Assets/
├── Animations/
│   ├── Player/
│   └── Fish/
├── Audio/
│   ├── BGM/
│   └── SFX/
├── Prefabs/
│   ├── Player/
│   ├── Fish/
│   └── Environment/
├── Scenes/
├── Scripts/
│   ├── Player/
│   ├── Fish/
│   ├── Managers/
│   ├── Gameplay/
│   └── UI/
├── Sprites/
│   ├── Characters/
│   ├── Environment/
│   └── UI/
└── Settings/
```

Ketentuan: - Ikuti struktur aktual jika proyek sudah berjalan. - Simpan
script di lokasi yang konsisten dengan tanggung jawabnya. - Jangan
membuat folder baru hanya untuk satu file tanpa alasan. - Jangan
memindahkan asset atau script tanpa memeriksa referensi Scene, Prefab,
dan `.meta`. - Jangan menghapus file yang tidak dikenal sebelum
memastikan kegunaannya.

## 7. Pedoman C# dan Unity

### 7.1 Gaya Kode

Ikuti konvensi proyek jika sudah ada. Jika belum: - Nama class, method,
dan property: `PascalCase`. - Nama variabel lokal dan parameter:
`camelCase`. - Field privat: `camelCase`. - Gunakan
`[SerializeField] private` untuk referensi Inspector yang perlu
diatur. - Gunakan `public` hanya jika menjadi bagian API
antarkomponen. - Hindari magic number; gunakan konstanta atau
konfigurasi bernama jelas. - Satu class sebaiknya memiliki tanggung
jawab yang jelas. - Komentar menjelaskan alasan atau logika yang tidak
jelas, bukan sekadar mengulang kode.

### 7.2 Praktik Unity

-   Gunakan `Time.deltaTime` untuk gerakan berbasis frame di `Update()`.
-   Gunakan `FixedUpdate()` untuk operasi yang terkait simulasi fisika.
-   Pilih `Rigidbody2D`, Collider2D, dan trigger sesuai kebutuhan.
-   Periksa Layer dan Physics 2D Collision Matrix saat menangani
    tabrakan.
-   Kelola `Instantiate` dan `Destroy` dengan hati-hati.
-   Bersihkan coroutine, event subscription, dan referensi pada
    lifecycle yang tepat.
-   Hindari operasi berat atau pencarian objek berulang di `Update()`.
-   Gunakan log debugging secara terarah dan hapus log yang tidak
    diperlukan sebelum rilis.

### 7.3 Input

Kontrol utama adalah WASD. Sebelum mengimplementasikan input, periksa
apakah proyek menggunakan Input System baru, Input Manager lama, atau
pendekatan lain. Jangan mengganti sistem input tanpa analisis dampak dan
persetujuan.

### 7.4 Fisika dan Collision

Tentukan apakah interaksi ikan menggunakan trigger atau collision.
Hindari mencampur mekanisme untuk kejadian yang sama tanpa alasan.

Pastikan: - Collider2D dan Rigidbody2D sesuai kebutuhan. - Satu kejadian
makan hanya diproses sekali. - Objek yang sudah dimangsa tidak memicu
skor berulang. - Kematian Player tidak memicu banyak transisi Game
Over. - Pengaturan Layer tidak menyebabkan interaksi yang tidak
diinginkan.

## 8. Rencana AI Ikan

Gunakan AI sederhana yang realistis untuk jadwal enam minggu. Finite
State Machine (FSM) dapat memisahkan perilaku.

  Jenis ikan    Perilaku minimum
  ------------- -----------------------------------------------------------
  Small Fish    Wander; Flee jika waktu memungkinkan
  Medium Fish   Wander dan mengejar ikan yang lebih kecil
  Predator      Wander/Patrol dan mengejar Player dalam jangkauan deteksi

Pedoman: - Gunakan state dan transisi yang mudah dipahami. - Batasi
kompleksitas deteksi dan pengejaran. - Hindari ikan bergerak tidak
terkendali atau keluar arena secara permanen. - Pastikan AI berhenti dan
melanjutkan dengan benar saat Pause/Resume. - Boids, pathfinding
kompleks, dan perilaku kawanan bukan prioritas versi awal.

## 9. Konvensi Integrasi dan Git

Ikuti proses GitHub di `WORKFLOW.md`.

-   Jangan mengerjakan fitur langsung pada `main`.
-   Gunakan branch berdasarkan fitur atau perbaikan.
-   Ambil perubahan terbaru sebelum memulai pekerjaan.
-   Buat commit dengan pesan yang menjelaskan perubahan.
-   Tinjau diff sebelum commit dan merge.
-   Jangan mengubah file milik fitur lain tanpa koordinasi.
-   Hindari dua anggota atau dua AI agent mengedit file yang sama
    bersamaan.
-   Jangan menghapus atau mengabaikan file `.meta`.
-   Jangan commit folder hasil generate lokal seperti `Library`, `Temp`,
    atau `Obj`.
-   Jangan mengubah konfigurasi project-wide tanpa menjelaskan
    dampaknya.

Contoh branch: - `feature/player-movement` - `feature/fish-ai` -
`feature/game-management` - `feature/ui` - `fix/fish-collision`

Contoh commit: - `feat: add player movement` -
`feat: implement fish eating` -
`fix: prevent duplicate score on collision` -
`refactor: separate fish data from ai behavior`

Saat mengubah Scene, Prefab, Project Settings, atau file rawan konflik,
periksa status Git dan koordinasikan dengan pemilik sistem.

## 10. Pembagian Tanggung Jawab Tim

  Anggota    Fokus utama
  ---------- ----------------------------------------------------------
  Member 1   Player, gerakan, sistem makan, pertumbuhan, dan kematian
  Member 2   AI ikan, jenis ikan, spawn, dan lingkungan arena
  Member 3   Game Manager, mode, skor, UI, dan alur menu

Semua anggota tetap bertanggung jawab atas integrasi, pengujian,
debugging, dan penyelesaian game.

AI harus memastikan file yang akan diubah sesuai ruang lingkup
pekerjaan. Jika implementasi membutuhkan perubahan pada sistem milik
anggota lain, jelaskan dan koordinasikan. Pembagian ini dapat diubah
jika tim menyepakatinya.

## 11. Aturan Wajib untuk AI Coding Assistant

### 11.1 Sebelum Mengubah Kode

1.  Baca instruksi pengguna dan identifikasi hasil yang diminta.
2.  Periksa struktur folder dan file terkait.
3.  Baca implementasi yang sudah ada sebelum mengusulkan pengganti.
4.  Periksa referensi antar-script, Scene, Prefab, dan Inspector jika
    relevan.
5.  Untuk perubahan multi-file atau berisiko, jelaskan rencana singkat
    dan file yang akan diubah.
6.  Jika informasi penting belum jelas, ajukan satu pertanyaan paling
    relevan sebelum mengambil keputusan besar.

### 11.2 Saat Mengubah Kode

-   Kerjakan satu fitur atau masalah dalam perubahan terfokus.
-   Ubah file sesedikit mungkin untuk memenuhi kebutuhan.
-   Jangan memodifikasi file yang tidak terkait.
-   Jangan membuat script duplikat sebelum mencari implementasi yang
    sudah ada.
-   Jangan mengganti arsitektur atau teknologi tanpa alasan dan
    persetujuan.
-   Jangan menghapus fitur yang sudah berjalan tanpa menjelaskan
    dampaknya.
-   Jangan menambahkan package atau dependency tanpa kebutuhan jelas.
-   Jangan menebak nama object, komponen, Scene, Prefab, atau field
    Inspector yang belum diverifikasi.
-   Jangan mengklaim perubahan berhasil diuji jika belum dijalankan.
-   Pertahankan kompatibilitas dengan Unity 6.6 dan konfigurasi aktual
    proyek.

### 11.3 Setelah Mengubah Kode

Sampaikan: 1. Ringkasan perubahan. 2. Daftar file yang dibuat atau
diubah. 3. Penjelasan singkat cara kerja. 4. Langkah pengujian di Unity.
5. Hasil pengujian yang benar-benar telah dilakukan. 6. Hal yang masih
perlu diperiksa atau keterbatasan.

Jika tidak dapat menjalankan Unity Editor atau build, nyatakan bahwa
pengujian runtime belum dilakukan. Jangan menyatakan fitur berfungsi
hanya berdasarkan penulisan kode.

### 11.4 Perubahan yang Memerlukan Persetujuan

Jangan melakukan hal berikut tanpa permintaan atau persetujuan
eksplisit: - Menghapus banyak file atau folder. - Mengganti struktur
besar proyek. - Mengubah versi Unity atau package utama. - Mengganti
sistem input atau fisika. - Mengubah pengaturan build global. - Mengubah
Scene/Prefab yang tidak terkait. - Menambahkan sistem kompleks yang
tidak dibutuhkan PRD. - Menimpa pekerjaan anggota tim lain.

Untuk perubahan berisiko, berhenti dan minta persetujuan terlebih
dahulu.

## 12. Cara AI Membantu Tim

Tim masih mempelajari Unity dan C#. Berikan penjelasan yang dapat
dipahami mahasiswa yang sedang belajar pengembangan game.

Ketika menjelaskan kode: - Jelaskan tujuan script dan tanggung
jawabnya. - Jelaskan komponen Unity yang harus dipasang pada
GameObject. - Jelaskan field Inspector yang perlu diisi. - Jelaskan
hubungan script dengan sistem lain. - Berikan langkah pengujian manual
yang konkret. - Jelaskan istilah teknis yang belum umum secara ringkas.

Ketika debugging: 1. Identifikasi gejala dan kemungkinan penyebab. 2.
Periksa kode dan konfigurasi yang relevan. 3. Pisahkan penyebab yang
terbukti dari dugaan. 4. Usulkan perbaikan terkecil yang masuk akal. 5.
Jelaskan cara memverifikasi perbaikan.

Jangan melakukan refactor besar ketika masalah dapat diselesaikan dengan
perubahan kecil.

## 13. Prioritas Pengembangan

Ikuti prioritas di `PRD.md`.

**Must-have** - Build Windows dapat dijalankan. - Main Menu dan
pemilihan mode. - Gerakan Player menggunakan WASD. - Ikan non-pemain
bergerak. - Aturan memangsa berdasarkan ukuran. - Skor dan
pertumbuhan. - Predator dapat memangsa Player. - Objective Mode dengan
Victory/Game Over. - Endless Mode sampai Player mati. - HUD,
Pause/Resume, Restart, dan kembali ke Main Menu.

**Should-have** - Spawn ikan dinamis yang terkontrol. - Perilaku Flee
untuk ikan kecil. - Animasi dasar dan penyempurnaan respons gerak. -
Audio dasar jika waktu memungkinkan.

**Could-have** - Boids atau AI lebih kompleks. - Variasi arena atau
level. - Efek visual tambahan. - Fitur tambahan yang tidak mengganggu
penyelesaian kebutuhan utama.

Jangan memulai fitur Could-have sebelum fitur Must-have selesai dan
diuji.

## 14. Keputusan yang Belum Final

Jangan menganggap hal berikut telah diputuskan: - Jenis target Objective
Mode: skor atau ukuran/pertumbuhan. - Nilai target Objective Mode. -
Nilai skor setiap jenis ikan. - Nilai pertumbuhan dan batas ukuran. -
Kecepatan setiap jenis ikan dan Player. - Jangkauan deteksi predator. -
Jumlah ikan awal dan batas maksimum spawn. - Mekanisme batas arena:
dinding atau keluar-masuk sisi layar. - Resolusi dan rasio layar
target. - Detail audio dan efek visual.

Gunakan nilai sementara hanya jika pengguna meminta prototipe atau
pengujian. Tandai sebagai konfigurasi sementara, bukan keputusan desain
final.

## 15. Checklist Sebelum Menyatakan Fitur Selesai

-   [ ] Implementasi sesuai kebutuhan `PRD.md`.
-   [ ] Tidak membuat duplikasi sistem atau script.
-   [ ] Tidak mengubah file yang tidak terkait.
-   [ ] Referensi Inspector, Scene, dan Prefab sudah diperiksa.
-   [ ] Tidak ada error compile yang diketahui.
-   [ ] Perilaku normal sudah diuji di Unity jika lingkungan
    memungkinkan.
-   [ ] Kondisi tepi yang relevan sudah dipertimbangkan.
-   [ ] Tidak merusak fitur yang sudah ada.
-   [ ] Perubahan sudah ditinjau melalui diff.
-   [ ] Ringkasan dan langkah pengujian sudah disampaikan kepada tim.

## 16. Dokumen Acuan

-   `PRD.md` --- kebutuhan produk, fitur, aturan gameplay, dan kriteria
    penerimaan.
-   `WORKFLOW.md` --- pembagian kerja, proses GitHub, jadwal enam
    minggu, dan standar kolaborasi.
-   `README.md` --- deskripsi repository dan instruksi menjalankan
    proyek.

**Instruksi akhir:** Bantu tim membangun Tiny Predators secara bertahap,
terukur, dan mudah dipahami. Utamakan kebutuhan inti yang realistis
diselesaikan dalam enam minggu. Selalu periksa kode aktual sebelum
mengubahnya, dan jangan mengarang status implementasi, konfigurasi, atau
hasil pengujian.
