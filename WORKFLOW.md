# Tiny Predators --- Development Workflow

Dokumen ini menjadi pedoman kerja tim untuk mengembangkan **Tiny
Predators**, game 2D Arcade Survival bertema kehidupan bawah laut.

> **Tujuan:** menjaga pekerjaan tiga anggota tim tetap terarah,
> memastikan integrasi dilakukan sejak awal, dan menghasilkan game
> Windows yang dapat dimainkan sampai selesai dalam waktu enam minggu.

------------------------------------------------------------------------

## 1. Informasi Proyek

  Aspek                 Keputusan
  --------------------- -----------------------------------------------
  Nama proyek           Tiny Predators
  Genre                 2D Arcade Survival
  Platform              PC / Windows
  Game engine           Unity 6.6
  Bahasa pemrograman    C#
  Code editor           Visual Studio Code
  Visual                Cartoon 2D
  Mode permainan        Objective Mode dan Endless Mode
  Arena                 Satu arena utama
  Kontrol               WASD
  Jumlah anggota        3 orang
  Durasi pengembangan   6 minggu
  Version control       Git dan GitHub
  Aset                  Kombinasi aset gratis dan aset buatan sendiri

### 1.1 Gambaran Gameplay

Pemain mengendalikan seekor ikan di arena bawah laut. Pemain mencari dan
memangsa ikan yang berukuran lebih kecil untuk memperoleh skor dan
bertumbuh. Ikan yang lebih besar dapat memangsa pemain. Jika pemain
dimangsa, permainan berakhir.

Dua mode permainan:

-   **Objective Mode:** pemain harus mencapai target skor atau
    pertumbuhan yang ditentukan untuk menang. Jika pemain mati sebelum
    mencapai target, permainan berakhir dengan Game Over.
-   **Endless Mode:** pemain mengumpulkan skor sebanyak mungkin tanpa
    target kemenangan. Permainan berakhir ketika pemain mati.

------------------------------------------------------------------------

## 2. Prinsip Pengembangan

Tim mengikuti prinsip berikut selama pengembangan:

1.  **Gameplay lebih dahulu, visual menyusul.** Pastikan mekanisme utama
    berfungsi sebelum menghabiskan waktu untuk dekorasi dan efek.
2.  **Buat versi yang dapat dimainkan sedini mungkin.** Targetkan core
    gameplay sederhana sudah berjalan pada akhir minggu kedua.
3.  **Integrasikan secara bertahap.** Jangan menunggu seluruh sistem
    selesai untuk menggabungkannya.
4.  **Satu sistem memiliki penanggung jawab.** Pemilik sistem
    bertanggung jawab atas implementasi, dokumentasi singkat, dan
    pengujian awal.
5.  **Hindari fitur di luar cakupan.** Fitur tambahan hanya dikerjakan
    jika semua fitur wajib stabil dan waktu masih tersedia.
6.  **Pahami kode yang dihasilkan AI.** Setiap anggota harus mampu
    menjelaskan dan menguji kode yang mereka gunakan.
7.  **Jaga proyek selalu dapat dibuka.** Setelah integrasi, proyek harus
    dapat dibuka dan dijalankan di Unity tanpa error kritis.

------------------------------------------------------------------------

## 3. Perangkat dan Standar Proyek

### 3.1 Perangkat

-   Unity Editor 6.6. Seluruh anggota harus menggunakan versi lengkap
    yang sama, termasuk nomor patch.
-   Visual Studio Code sebagai editor kode.
-   Git dan GitHub untuk version control dan kolaborasi.
-   GitHub Copilot dan/atau Antigravity sebagai AI coding assistant.
-   Aplikasi pengolah grafis sesuai kebutuhan pembuatan atau penyesuaian
    aset.

### 3.2 Pengaturan Unity untuk Kolaborasi

Sebelum mulai bekerja bersama, pastikan pengaturan berikut diterapkan
pada proyek:

1.  Buka `Edit > Project Settings > Editor`.
2.  Atur **Asset Serialization** menjadi `Force Text`.
3.  Atur **Version Control Mode** menjadi `Visible Meta Files`.
4.  Pastikan seluruh anggota menggunakan versi Unity Editor dan package
    yang konsisten.
5.  Simpan perubahan pengaturan ke repository.

Unity menyimpan file `.meta` untuk menghubungkan aset dengan GUID. File
`.meta` harus ikut dilacak Git dan tidak boleh dihapus atau dibuat ulang
sembarangan.

### 3.3 Struktur Folder Awal

Gunakan struktur berikut sebagai titik awal. Folder dapat ditambah jika
memang diperlukan, tetapi perubahan struktur harus disepakati tim.

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
│   ├── MainMenu.unity
│   └── Game.unity
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

Folder `Packages` dan `ProjectSettings` dikelola oleh Unity dan harus
ikut masuk repository. Folder `Library`, `Temp`, `Obj`, dan file hasil
build lokal umumnya tidak perlu di-commit.

------------------------------------------------------------------------

## 4. Pembagian Tanggung Jawab

Pembagian berikut merupakan kepemilikan sistem utama. Semua anggota
tetap wajib membantu integrasi, pengujian, dan memahami alur permainan
secara keseluruhan.

### Anggota 1 --- Player System

Tanggung jawab utama:

-   Player movement menggunakan WASD.
-   Interaksi dan mekanisme memangsa ikan.
-   Sistem pertumbuhan ukuran pemain.
-   Collision dan kondisi kematian pemain.
-   Animasi karakter pemain.
-   Pengujian pergerakan dan interaksi pemain.

### Anggota 2 --- Fish AI dan Environment

Tanggung jawab utama:

-   Pergerakan ikan non-player.
-   Perilaku ikan kecil, ikan sedang, dan predator.
-   Sistem spawning ikan.
-   Prefab dan konfigurasi ikan.
-   Arena, background, serta dekorasi lingkungan.
-   Pengujian perilaku AI dan kemunculan ikan.

### Anggota 3 --- Game Management dan UI

Tanggung jawab utama:

-   Game state dan alur permainan.
-   Sistem skor.
-   Objective Mode dan Endless Mode.
-   Main Menu dan pemilihan mode.
-   HUD, indikator pertumbuhan, Pause, Victory, dan Game Over.
-   Integrasi audio serta pengujian alur UI.

### Tanggung jawab bersama

-   Meninjau perubahan sebelum merge.
-   Menguji hasil integrasi.
-   Menyelesaikan konflik Git bersama pemilik file terkait.
-   Memperbarui dokumentasi ketika ada perubahan desain atau
    implementasi.
-   Memastikan build final berjalan pada Windows.

------------------------------------------------------------------------

## 5. Rancangan Sistem dan Batas Tanggung Jawab

Nama script di bawah merupakan usulan awal. Tim boleh menyesuaikannya
setelah memahami kebutuhan implementasi, tetapi tanggung jawab setiap
sistem harus tetap jelas.

  -----------------------------------------------------------------------
  Sistem                  Script/komponen awal    Tanggung jawab
  ----------------------- ----------------------- -----------------------
  Player                  `PlayerController`      Membaca input dan
                                                  menggerakkan pemain

  Player                  `PlayerGrowth`          Mengelola level/ukuran
                                                  gameplay pemain

  Player                  `PlayerHealth` atau     Mengelola kondisi hidup
                          status hidup            dan mati

  Fish                    `FishAI`                Menjalankan perilaku
                                                  ikan

  Fish                    `FishData`              Menyimpan atribut ikan

  Fish                    `FishSpawner`           Mengatur kemunculan
                                                  ikan

  Gameplay                `GameManager`           Mengelola status dan
                                                  alur permainan

  Gameplay                `ScoreManager`          Mengelola skor

  UI                      `UIManager`             Memperbarui tampilan
                                                  dan menangani UI
  -----------------------------------------------------------------------

### 5.1 Aturan komunikasi antarsistem

-   Sistem Player tidak boleh mengubah teks UI secara langsung.
-   Sistem UI tidak boleh mengambil alih logika aturan memangsa.
-   Sistem AI bertanggung jawab atas perilaku ikan, sedangkan aturan
    apakah ikan dapat dimangsa harus ditentukan oleh logika gameplay
    yang disepakati.
-   Perubahan skor dan pertumbuhan harus berasal dari satu proses yang
    jelas agar tidak terjadi penghitungan ganda.
-   Gunakan event atau method publik dengan tujuan yang jelas untuk
    komunikasi antarsistem. Jangan membuat semua script saling
    bergantung.
-   Hindari `FindObjectOfType`/pencarian objek berulang di setiap frame.
    Referensi komponen sebaiknya diatur secara eksplisit atau melalui
    mekanisme yang disepakati.

### 5.2 Aturan ukuran ikan

Jangan menjadikan ukuran visual sprite sebagai satu-satunya penentu
aturan memangsa. Gunakan nilai gameplay yang eksplisit, misalnya
`sizeLevel`, `sizeValue`, atau atribut sejenis.

Aturan dasar:

-   Pemain hanya dapat memangsa ikan yang nilai ukurannya lebih kecil.
-   Ikan yang lebih besar dapat memangsa pemain.
-   Perubahan skala sprite harus mengikuti data pertumbuhan, bukan
    menjadi sumber kebenaran aturan gameplay.

Nilai ukuran, skor per ikan, dan target Objective Mode ditentukan dan
diuji saat balancing.

### 5.3 AI ikan

Mulai dari perilaku sederhana menggunakan Finite State Machine (FSM)
atau logika state yang setara.

-   Ikan kecil: wander; menghindar dari ancaman jika diperlukan.
-   Ikan sedang: wander dan mengejar ikan yang dapat dimangsanya.
-   Predator: wander/patrol dan mengejar pemain ketika berada dalam
    jangkauan deteksi.

Boids, pathfinding kompleks, dan perilaku lanjutan bukan fitur wajib
untuk versi awal.

------------------------------------------------------------------------

## 6. Git dan GitHub Workflow

### 6.1 Strategi branch

Gunakan `main` sebagai branch utama yang stabil. Setiap fitur
dikembangkan pada branch terpisah.

Contoh nama branch:

``` text
main
feature/player-movement
feature/player-eating-growth
feature/fish-ai
feature/fish-spawner
feature/game-modes
feature/ui
fix/player-collision
```

Branch dibuat berdasarkan fitur, bukan harus satu branch permanen untuk
setiap anggota. Dengan demikian, pekerjaan dapat dipecah menjadi bagian
kecil dan ditinjau lebih mudah.

### 6.2 Alur kerja setiap perubahan

1.  Ambil perubahan terbaru dari `main`.
2.  Buat branch untuk satu fitur atau perbaikan.
3.  Kerjakan perubahan pada branch tersebut.
4.  Jalankan Unity dan uji fitur yang diubah.
5.  Periksa file yang berubah sebelum commit.
6.  Commit dengan pesan yang menjelaskan perubahan.
7.  Push branch ke GitHub.
8.  Buat Pull Request menuju `main`.
9.  Minta anggota lain meninjau perubahan yang relevan.
10. Setelah disetujui dan diuji, merge ke `main`.
11. Anggota lain mengambil perubahan terbaru dan memastikan proyek tetap
    berjalan.

### 6.3 Contoh commit message

``` text
feat: add player movement
feat: implement fish eating logic
feat: add fish wander behavior
fix: correct player collision
ui: add game over panel
refactor: separate score logic
docs: update project workflow
```

Gunakan pesan commit yang singkat, spesifik, dan konsisten.

### 6.4 Aturan file Unity

-   Selalu commit file `.meta` bersama aset terkait.
-   Jangan commit folder `Library`, `Temp`, `Obj`, atau hasil build
    lokal kecuali tim memiliki alasan khusus.
-   Jangan mengubah atau menghapus `.meta` secara manual tanpa alasan
    yang jelas.
-   Hindari dua anggota mengedit Scene atau Prefab yang sama pada waktu
    bersamaan.
-   Jika beberapa orang perlu mengubah Scene yang sama, tentukan satu
    integrator/pemilik Scene.
-   Jika terjadi konflik Scene atau Prefab, selesaikan bersama pemilik
    perubahan dan uji hasilnya di Unity.
-   Aktifkan dan konfigurasi UnityYAMLMerge (Smart Merge) jika
    memungkinkan. Smart Merge membantu, tetapi bukan jaminan semua
    konflik dapat diselesaikan otomatis.

### 6.5 File yang perlu masuk repository

Pastikan repository menyertakan:

-   `Assets/`
-   `Packages/`
-   `ProjectSettings/`
-   `.gitignore`
-   `README.md`
-   `WORKFLOW.md`
-   Dokumen konteks AI jika digunakan.

------------------------------------------------------------------------

## 7. Rencana Pengembangan Enam Minggu

Jadwal ini adalah target kerja, bukan larangan untuk menyesuaikan urutan
jika ditemukan hambatan. Setiap minggu harus menghasilkan sesuatu yang
dapat diperiksa dan dijalankan.

### Minggu 1 --- Project Setup dan Prototype

**Anggota 1** - Membuat player GameObject dan input WASD. - Menguji
gerakan horizontal dan vertikal. - Mengatur batas gerak arena jika sudah
tersedia.

**Anggota 2** - Membuat satu prefab ikan sederhana. - Membuat pergerakan
wander dasar. - Menyiapkan arena dan aset sementara.

**Anggota 3** - Menyiapkan GameManager dasar. - Membuat kerangka Main
Menu dan Game Scene. - Menyiapkan struktur UI awal.

**Target akhir minggu:** - Ketiga anggota dapat membuka proyek dari
repository. - Proyek dapat dijalankan. - Player dapat bergerak. -
Setidaknya satu ikan dapat bergerak di arena.

### Minggu 2 --- Core Gameplay

**Anggota 1** - Mengimplementasikan deteksi dan mekanisme memangsa. -
Mengimplementasikan pertumbuhan player. - Mengimplementasikan kondisi
player mati.

**Anggota 2** - Membuat beberapa jenis ikan dengan nilai ukuran
berbeda. - Menyiapkan collision/trigger ikan. - Membuat predator dasar.

**Anggota 3** - Membuat alur status Playing dan Game Over. - Menyiapkan
pencatatan skor dasar. - Mengintegrasikan event memangsa dan kematian
dengan sistem game.

**Target akhir minggu:** - Player dapat memangsa ikan yang lebih
kecil. - Player bertambah besar setelah makan. - Ikan yang lebih besar
dapat memangsa player. - Permainan memiliki kondisi Game Over.

### Minggu 3 --- AI dan Sistem Permainan

**Anggota 1** - Memperbaiki gerakan, collision, dan pertumbuhan. -
Menguji interaksi player dengan seluruh kategori ikan.

**Anggota 2** - Mengembangkan FSM ikan kecil, sedang, dan predator. -
Mengembangkan FishSpawner. - Menguji jumlah dan perilaku ikan di arena.

**Anggota 3** - Menyelesaikan ScoreManager. - Mengimplementasikan
Objective Mode dan Endless Mode. - Menguji kondisi Victory dan Game Over
untuk kedua mode.

**Target akhir minggu:** - AI dasar berjalan. - Ikan muncul secara
terkontrol. - Skor berfungsi. - Kedua mode dapat dimainkan dengan aturan
yang sesuai.

### Minggu 4 --- UI dan Integrasi

**Anggota 1** - Mengintegrasikan animasi player. - Memperbaiki respons
gerakan dan interaksi.

**Anggota 2** - Menyelesaikan arena dan integrasi aset ikan. -
Memperbaiki perilaku dan spawning.

**Anggota 3** - Menyelesaikan Main Menu dan pemilihan mode. -
Menyelesaikan HUD, Pause, Victory, dan Game Over. - Mengintegrasikan UI
dengan sistem gameplay.

**Target akhir minggu:** - Seluruh alur permainan dapat dimainkan dari
Main Menu hingga akhir permainan. - UI utama terhubung dengan sistem
gameplay.

### Minggu 5 --- Polish, Balancing, dan Testing

**Seluruh anggota** - Memperbaiki bug berdasarkan hasil pengujian. -
Menyesuaikan kecepatan dan perilaku ikan. - Menyesuaikan pertumbuhan,
skor, dan target Objective Mode. - Menambahkan animasi, audio, dan efek
visual yang prioritas. - Menguji alur Objective dan Endless berulang
kali.

**Target akhir minggu:** - Fitur wajib stabil. - Tidak ada bug kritis
yang menghalangi permainan. - Tampilan dan audio utama sudah
terintegrasi.

### Minggu 6 --- Final Build dan Finalisasi

**Seluruh anggota** - Membekukan fitur baru kecuali perbaikan bug
penting. - Melakukan pengujian regresi. - Membuat build Windows. -
Menguji build pada komputer di luar Unity Editor. - Memeriksa kontrol,
UI, audio, dan kedua mode. - Menyiapkan dokumentasi dan bahan
presentasi.

**Target akhir minggu:** - Build Windows dapat dimainkan dari awal
sampai akhir. - Fitur wajib berjalan. - Proyek dan repository dalam
kondisi rapi. - Bahan presentasi siap.

------------------------------------------------------------------------

## 8. Definition of Done

Sebuah fitur baru boleh dianggap selesai jika:

1.  Implementasi sesuai kebutuhan fitur.
2.  Tidak menimbulkan error atau warning baru yang belum dipahami.
3.  Sudah diuji di Unity Editor.
4.  Tidak merusak fitur yang sudah ada.
5.  Perubahan sudah di-commit dan di-push.
6.  Dokumentasi diperbarui jika ada perubahan cara kerja sistem.

### Kriteria minimum game final

-   [ ] Game dapat dijalankan sebagai build Windows.
-   [ ] Player dapat bergerak menggunakan WASD.
-   [ ] Ikan non-player dapat bergerak.
-   [ ] Player hanya dapat memangsa ikan yang lebih kecil.
-   [ ] Player bertumbuh setelah memangsa ikan.
-   [ ] Ikan yang lebih besar dapat memangsa player.
-   [ ] Skor bertambah sesuai aturan.
-   [ ] Objective Mode memiliki target dan kondisi Victory.
-   [ ] Endless Mode berjalan sampai player mati.
-   [ ] Main Menu dan pemilihan mode berfungsi.
-   [ ] HUD menampilkan informasi yang diperlukan.
-   [ ] Pause dan Game Over berfungsi.
-   [ ] Restart dan kembali ke Main Menu berfungsi.
-   [ ] Build telah diuji tanpa menjalankan Unity Editor.

------------------------------------------------------------------------

## 9. Standar Penggunaan AI Coding Assistant

AI seperti GitHub Copilot dan Antigravity boleh digunakan untuk membantu
pemahaman, implementasi, debugging, refactoring, dan dokumentasi.

Aturan penggunaan:

1.  Berikan konteks proyek dan file terkait sebelum meminta perubahan.
2.  Minta AI mengerjakan satu fitur atau masalah dalam satu waktu.
3.  Minta penjelasan untuk perubahan yang memengaruhi arsitektur.
4.  Batasi perubahan pada file yang relevan.
5.  Periksa kode dan diff sebelum menerima perubahan.
6.  Jalankan dan uji hasilnya di Unity.
7.  Jangan menerima perubahan yang tidak dipahami hanya karena AI
    menyatakan tugas selesai.
8.  Jangan membiarkan dua AI atau dua anggota mengubah file yang sama
    secara bersamaan tanpa koordinasi.
9.  Jangan memasukkan secret, token, atau kredensial ke prompt maupun
    repository.
10. Perbarui dokumen konteks AI ketika struktur atau keputusan proyek
    berubah.

### Konteks minimum untuk prompt AI

Sertakan informasi berikut saat meminta bantuan:

-   Proyek: Tiny Predators.
-   Engine: Unity 6.6.
-   Bahasa: C#.
-   Platform: Windows.
-   Sistem yang sedang dikerjakan.
-   File terkait.
-   Perilaku yang diharapkan.
-   Batasan file yang boleh diubah.
-   Cara menguji hasilnya.

------------------------------------------------------------------------

## 10. Komunikasi dan Koordinasi Tim

Agar pekerjaan tidak saling menunggu:

-   Adakan koordinasi singkat secara rutin untuk menyampaikan pekerjaan
    selesai, pekerjaan berikutnya, dan hambatan.
-   Setiap anggota memperbarui status tugas pada papan kerja bersama.
-   Sepakati perubahan desain atau arsitektur sebelum diterapkan.
-   Jika suatu fitur tertunda, segera sampaikan dampaknya kepada anggota
    lain.
-   Lakukan sesi integrasi minimal satu kali setiap minggu; pada minggu
    kedua hingga keenam, integrasi sebaiknya lebih sering jika
    diperlukan.

Format laporan singkat anggota:

``` text
Anggota:
Tanggal:

Selesai:
- ...

Sedang dikerjakan:
- ...

Kendala:
- ...

File/branch yang berubah:
- ...

Rencana berikutnya:
- ...
```

------------------------------------------------------------------------

## 11. Manajemen Risiko dan Prioritas Fitur

### Risiko utama

  -----------------------------------------------------------------------
  Risiko                              Mitigasi
  ----------------------------------- -----------------------------------
  Core gameplay terlambat selesai     Prioritaskan prototype dan
                                      mekanisme makan pada minggu
                                      pertama-kedua

  Konflik Scene/Prefab                Batasi pemilik file dan
                                      koordinasikan perubahan

  AI ikan terlalu rumit               Mulai dari FSM sederhana

  Integrasi terlambat                 Integrasi rutin sejak minggu
                                      pertama

  Aset tidak konsisten                Tetapkan panduan visual dan gunakan
                                      aset sementara lebih dahulu

  Perubahan AI merusak kode           Review diff, commit sebelum
                                      perubahan besar, dan uji ulang

  Build bermasalah                    Lakukan percobaan build sebelum
                                      minggu terakhir
  -----------------------------------------------------------------------

### Prioritas fitur

**Wajib:** - Pergerakan player. - Ikan kecil, sedang, dan predator. -
Mekanisme memangsa. - Pertumbuhan. - Kematian player. - AI dasar. -
Spawning ikan. - Skor. - Objective dan Endless Mode. - UI utama. - Build
Windows.

**Tambahan jika waktu memungkinkan:** - Variasi animasi dan efek
memangsa. - Audio dan musik tambahan. - Variasi dekorasi arena. -
Perilaku AI yang lebih beragam. - Efek visual tambahan.

Fitur tambahan tidak boleh menghambat penyelesaian fitur wajib.

------------------------------------------------------------------------

## 12. Checklist Sebelum Memulai Implementasi

-   [ ] Semua anggota menggunakan Unity Editor dengan versi lengkap yang
    sama.
-   [ ] Proyek utama sudah dibuat dan dapat dibuka semua anggota.
-   [ ] VS Code sudah dipilih sebagai External Script Editor.
-   [ ] Repository GitHub sudah tersedia.
-   [ ] Pengaturan Force Text dan Visible Meta Files sudah diterapkan.
-   [ ] `.gitignore` Unity sudah digunakan.
-   [ ] Struktur folder sudah disepakati.
-   [ ] Branch dan aturan Pull Request sudah disepakati.
-   [ ] Pembagian tanggung jawab sudah disepakati.
-   [ ] Aset sementara untuk prototype tersedia.
-   [ ] Dokumen konteks AI sudah tersedia.
-   [ ] Uji kolaborasi GitHub berhasil dilakukan.

------------------------------------------------------------------------

## 13. Aturan Perubahan Workflow

Dokumen ini dapat diperbarui jika tim menemukan kebutuhan teknis atau
perubahan desain yang penting.

Setiap perubahan yang memengaruhi fitur, arsitektur, pembagian tugas,
atau jadwal harus:

1.  Dibahas dan disepakati tim.
2.  Dicatat dalam dokumentasi proyek.
3.  Diperbarui pada dokumen workflow ini.
4.  Disampaikan kepada seluruh anggota sebelum diterapkan.

**Prinsip akhir:** Tiny Predators dinyatakan siap dikumpulkan ketika
seluruh fitur wajib berjalan stabil, kedua mode dapat dimainkan, dan
build Windows telah diuji secara mandiri.
