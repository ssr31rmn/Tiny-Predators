# TASKS.md --- Tiny Predators

> **Dokumen kerja pengembangan** untuk proyek game *Tiny Predators*.
> Dokumen ini menjadi daftar pekerjaan, urutan dependensi, panduan
> implementasi, dan kriteria penyelesaian selama target pengembangan
> enam minggu.
>
> **Status dokumen:** Baseline awal --- dapat diperbarui setelah
> keputusan tim atau hasil pengujian berubah.

------------------------------------------------------------------------

## 1. Informasi Proyek

  Item                 Keputusan
  -------------------- -----------------------------
  Nama proyek          Tiny Predators
  Genre                2D Arcade Survival
  Platform target      PC / Windows
  Engine               Unity 6.6 --- `6000.6.0f1`
  Template             Universal 2D
  Bahasa pemrograman   C#
  Input                Input Manager (Old)
  Pemain               Single-player
  Tim                  3 orang
  Target waktu         6 minggu
  Version control      Git dan GitHub
  IDE/editor kode      Visual Studio Code
  Kebijakan AI         Confirmation Before Changes

### 1.1 Ringkasan gameplay

Pemain mengendalikan seekor ikan di arena bawah laut. Pemain dapat
memakan ikan yang ukurannya lebih kecil untuk memperoleh skor dan
meningkatkan pertumbuhan. Ikan yang lebih besar dapat memangsa pemain.

Jenis entitas utama: - **Player:** ikan yang dikendalikan pemain. -
**Small Fish:** ikan kecil yang umumnya menjadi mangsa. - **Medium
Fish:** ikan menengah yang dapat memangsa ikan lebih kecil. -
**Predator:** ikan besar yang menjadi ancaman bagi pemain.

Game memiliki dua mode: - **Objective Mode:** pemain menang ketika
mencapai target pertumbuhan yang ditentukan. - **Endless Mode:**
permainan berlanjut sampai pemain dimangsa; hasil utama berfokus pada
skor dan survival.

Aturan makan ditentukan berdasarkan atribut ukuran eksplisit, misalnya
`sizeLevel`, bukan berdasarkan ukuran visual `Transform.localScale`.

### 1.2 Keputusan desain yang menjadi acuan

1.  Arena menggunakan dinding/batas fisik agar ikan tidak keluar dari
    area permainan.
2.  Input menggunakan Input Manager (Old), bukan mengasumsikan New Input
    System aktif hanya karena file Input Actions tersedia.
3.  Aset visual menggunakan kombinasi aset gratis yang sesuai lisensinya
    dan aset buatan sendiri.
4.  AI ikan dibuat berdasarkan perilaku sederhana yang dapat
    diselesaikan dalam waktu enam minggu. Boids bersifat opsional dan
    hanya dikerjakan jika fitur inti sudah stabil.
5.  Satu arena menjadi target versi awal. Arena tambahan bukan
    prioritas.
6.  Fitur inti harus berfungsi sebelum pekerjaan polish, efek tambahan,
    atau fitur opsional dimulai.

------------------------------------------------------------------------

## 2. Cara Menggunakan TASKS.md

### 2.1 Status pekerjaan

Gunakan salah satu status berikut pada kolom status setiap task:

-   `Not Started` --- belum dikerjakan.
-   `In Progress` --- sedang dikerjakan.
-   `Blocked` --- terhambat oleh dependensi atau masalah yang belum
    diselesaikan.
-   `Review` --- implementasi selesai dan menunggu pemeriksaan anggota
    tim.
-   `Done` --- seluruh acceptance criteria terpenuhi dan perubahan sudah
    terintegrasi.

Jangan mengubah status menjadi `Done` hanya karena kode sudah ditulis.
Task harus memenuhi kriteria penerimaan dan diuji.

### 2.2 Prioritas

  -----------------------------------------------------------------------
  Prioritas                           Arti
  ----------------------------------- -----------------------------------
  P0 --- Critical                     Wajib untuk menghasilkan game yang
                                      dapat dimainkan dan diselesaikan.

  P1 --- High                         Sangat penting untuk pengalaman
                                      bermain dan kelengkapan fitur
                                      utama.

  P2 --- Medium                       Dikerjakan setelah fitur inti
                                      stabil; dapat disederhanakan bila
                                      waktu terbatas.

  P3 --- Optional                     Hanya dikerjakan jika seluruh
                                      kebutuhan P0 dan P1 sudah aman.
  -----------------------------------------------------------------------

### 2.3 Estimasi waktu

-   Estimasi menggunakan **jam kerja aktif per task**, bukan durasi
    kalender.
-   Estimasi adalah perkiraan awal untuk implementasi, pemeriksaan, dan
    perbaikan ringan.
-   Waktu belajar, diskusi tim, konflik Git, dan bug tak terduga dapat
    menambah durasi.
-   Beberapa task dapat dikerjakan paralel jika dependensinya terpenuhi.
-   Total estimasi bukan berarti satu orang harus mengerjakan seluruh
    pekerjaan.

### 2.4 Pembagian tanggung jawab yang fleksibel

Gunakan peran pekerjaan, bukan penetapan anggota permanen:

  -----------------------------------------------------------------------
  Peran kerja                         Fokus tanggung jawab
  ----------------------------------- -----------------------------------
  Gameplay                            Player controller, aturan makan,
                                      pertumbuhan, skor, kondisi
                                      menang/kalah.

  AI & World                          Fish behavior, spawning, arena,
                                      batas dan interaksi lingkungan.

  UI & Integration                    UI, menu, game flow, integrasi,
                                      testing, build dan dokumentasi.
  -----------------------------------------------------------------------

Ketiga peran dapat saling membantu. Tim perlu menetapkan pemilik task
aktual saat planning mingguan. Setiap task tetap memiliki satu orang
yang bertanggung jawab mengoordinasikan penyelesaiannya.

------------------------------------------------------------------------

## 3. Gambaran Fase dan Jadwal Enam Minggu

  Fase   Fokus                                Target minggu Prioritas
  ------ ---------------------------------- --------------- -----------
  1      Project Setup & Team Foundation           Minggu 1 P0
  2      Player System                          Minggu 1--2 P0
  3      Fish Entity System                     Minggu 1--3 P0
  4      Core Gameplay & Growth                 Minggu 2--3 P0
  5      AI Behavior & Fish Spawning               Minggu 3 P0/P1
  6      Game Flow & Game Modes                 Minggu 3--4 P0
  7      UI, Arena & Visual Assets                 Minggu 4 P0/P1
  8      Integration & Functional Testing       Minggu 4--5 P0
  9      Polish, Balancing & Optimization          Minggu 5 P1/P2
  10     Final Build & Delivery                    Minggu 6 P0

**Urutan penting:** Player System, Fish Entity System, dan Core Gameplay
menjadi fondasi AI, mode permainan, serta UI. Jangan menunggu seluruh
aset final tersedia untuk mulai menguji gameplay; gunakan placeholder
sementara.

------------------------------------------------------------------------

# 4. Daftar Task

## Fase 1 --- Project Setup & Team Foundation

**Target:** Minggu 1\
**Tujuan fase:** Menyiapkan proyek Unity, struktur folder, version
control, dan aturan kerja tim.

### TP-001 --- Verifikasi dan konfigurasi dasar proyek

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** Tidak ada
-   **Status:** Done

**Tujuan:** Memastikan proyek Unity yang sudah dibuat siap digunakan
sebagai basis pengembangan.

**Panduan implementasi:** 1. Buka proyek Tiny Predators menggunakan
Unity Editor versi `6000.6.0f1`. 2. Pastikan template proyek adalah
Universal 2D. 3. Periksa bahwa Scene awal dapat dibuka tanpa error. 4.
Buka `Edit > Project Settings > Player`. 5. Periksa pengaturan Active
Input Handling dan pastikan penggunaan Input Manager (Old) sesuai
keputusan tim. Jangan mengubahnya tanpa persetujuan tim karena perubahan
backend input dapat memengaruhi implementasi. 6. Pastikan target
platform adalah PC, Mac & Linux Standalone dengan target build Windows.
7. Simpan Scene awal di lokasi yang disepakati tim.

**Panduan Inspector/Editor:** - Project Settings: Player, Resolution and
Presentation, Other Settings. - Package Manager: periksa package yang
diperlukan, jangan memperbarui package secara massal tanpa alasan.

**Pengujian manual:** - Buka dan tutup Scene. - Jalankan Play Mode
sebentar untuk memastikan Editor dapat menjalankan Scene awal. - Periksa
Console.

**Acceptance criteria:** - Proyek terbuka menggunakan versi Unity yang
disepakati. - Template Universal 2D terdeteksi. - Input backend sesuai
keputusan tim. - Scene awal dapat dibuka dan Play Mode dapat
dijalankan. - Tidak ada error kompilasi yang belum ditangani.

**Output:** Konfigurasi dasar proyek terverifikasi.

### TP-002 --- Membuat struktur folder proyek

-   **Prioritas:** P0
-   **Estimasi:** 1 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-001
-   **Status:** Done

**Tujuan:** Menjaga aset dan script tetap terorganisasi.

**Panduan implementasi:** Buat struktur folder awal berikut di dalam
`Assets/`:

``` text
Assets/
├── Animations/
├── Audio/
├── Materials/
├── Prefabs/
│   ├── Player/
│   ├── Fish/
│   └── Environment/
├── Scenes/
├── Scripts/
│   ├── Player/
│   ├── Fish/
│   ├── AI/
│   ├── Gameplay/
│   ├── UI/
│   └── Managers/
├── Sprites/
│   ├── Player/
│   ├── Fish/
│   ├── Environment/
│   └── UI/
└── Settings/
```

Folder dapat disesuaikan jika ada kebutuhan nyata, tetapi hindari
membuat terlalu banyak folder kosong atau struktur yang tumpang tindih.

**Panduan Inspector/Editor:** Gunakan jendela Project untuk membuat
folder. Tidak memerlukan pengaturan Inspector khusus.

**Pengujian manual:** - Pastikan seluruh folder berada di dalam
`Assets/`. - Pastikan folder `Settings/` bawaan template tidak tertimpa
atau dihapus.

**Acceptance criteria:** - Struktur folder tersedia dan mudah
dipahami. - Aset bawaan template tetap aman.

**Output:** Struktur folder proyek.

### TP-003 --- Menyiapkan Git dan GitHub

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-001
-   **Status:** Done

**Tujuan:** Memungkinkan tiga anggota tim bekerja pada proyek yang sama
dengan riwayat perubahan yang dapat ditinjau.

**Panduan implementasi:** 1. Pastikan proyek menggunakan Unity Version
Control yang sesuai untuk kolaborasi berbasis Git. 2. Buat atau gunakan
repository GitHub tim yang sudah disepakati. 3. Tambahkan `.gitignore`
khusus Unity. 4. Pastikan folder `Assets/`, `Packages/`, dan
`ProjectSettings/` masuk version control. 5. Pastikan folder sementara
seperti `Library/`, `Temp/`, `Logs/`, dan `Obj/` tidak ikut di-commit.
6. Aktifkan Visible Meta Files dan Force Text pada pengaturan Editor
jika belum aktif, agar referensi aset dan file Scene lebih aman untuk
kolaborasi. 7. Lakukan commit awal setelah struktur proyek stabil. 8.
Setiap anggota melakukan clone/pull dan membuka proyek menggunakan versi
Unity yang sama.

**Panduan Inspector/Editor:** - `Edit > Project Settings > Editor`. -
Version Control: Visible Meta Files. - Asset Serialization: Force Text.

**Pengujian manual:** - Satu anggota membuat perubahan kecil pada file
uji atau dokumentasi. - Anggota lain melakukan pull dan memastikan
perubahan terlihat. - Pastikan file `.meta` untuk aset yang dilacak ikut
masuk Git.

**Acceptance criteria:** - Repository dapat diakses seluruh anggota. -
File penting proyek Unity terlacak. - File hasil generate sementara
tidak ikut di-commit. - Anggota dapat melakukan pull tanpa kehilangan
perubahan lokal.

**Output:** Repository GitHub siap digunakan dan aturan dasar kolaborasi
disepakati.

### TP-004 --- Menetapkan workflow kolaborasi dan penggunaan AI

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Seluruh anggota
-   **Dependensi:** TP-003
-   **Status:** Done

**Tujuan:** Menghindari konflik pekerjaan dan perubahan yang tidak
disetujui.

**Panduan implementasi:** 1. Tentukan pemilik task dan branch/strategi
integrasi yang digunakan tim. 2. Sepakati format commit yang mudah
dibaca. 3. Jangan mengerjakan file Scene atau Prefab yang sama secara
bersamaan tanpa koordinasi. 4. Lakukan pull sebelum memulai pekerjaan
dan sebelum integrasi. 5. Gunakan workflow AI dengan kebijakan
Confirmation Before Changes. 6. AI boleh membaca, menganalisis, dan
mengusulkan perubahan tanpa mengubah proyek. 7. AI harus meminta
persetujuan eksplisit sebelum mengubah script, GameObject, komponen,
Inspector, Prefab, Scene, Project Settings, menghapus aset, atau
menjalankan tindakan Git yang mengubah repository. 8. Persetujuan hanya
berlaku untuk lingkup perubahan yang disetujui. 9. Setelah perubahan
diterapkan, periksa hasilnya di Unity Editor dan lakukan pengujian
manual.

**Acceptance criteria:** - Tim memahami aturan branch, commit, pull, dan
integrasi. - Tim memahami batas tindakan AI. - Tidak ada perubahan
proyek yang dilakukan AI tanpa persetujuan eksplisit.

**Output:** Workflow kolaborasi tim yang disepakati.

------------------------------------------------------------------------

## Fase 2 --- Player System

**Target:** Minggu 1--2\
**Tujuan fase:** Menghasilkan Player yang dapat dikendalikan, memiliki
batas gerak, dan dapat menerima interaksi gameplay.

### TP-005 --- Membuat Player GameObject dan komponen dasar

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-001, TP-002
-   **Status:** Done

**Tujuan:** Membuat objek Player sebagai entitas utama game.

**Panduan implementasi:** 1. Buat GameObject Player di Scene gameplay.
2. Tambahkan SpriteRenderer menggunakan sprite sementara jika aset final
belum tersedia. 3. Tambahkan Rigidbody2D. 4. Tambahkan Collider2D yang
sesuai dengan bentuk sprite. 5. Buat layer/tag Player jika dibutuhkan
untuk identifikasi dan collision filtering. 6. Atur posisi awal dan
ukuran visual agar sesuai dengan skala dunia game. 7. Ubah Player
menjadi Prefab setelah konfigurasi dasar stabil.

**Panduan Inspector:** - Transform: posisi awal dan skala visual. -
SpriteRenderer: Sprite, Sorting Layer, Order in Layer. - Rigidbody2D:
Body Type Dynamic; atur Gravity Scale sesuai kebutuhan game top-down
(umumnya 0). - Collider2D: ukuran dan offset mengikuti bentuk sprite. -
Pastikan pengaturan Rigidbody2D dan Collider2D tidak menyebabkan Player
jatuh karena gravitasi.

**Pengujian manual:** - Jalankan Play Mode. - Pastikan Player
terlihat. - Pastikan Collider2D dan Rigidbody2D terpasang. - Periksa
Console.

**Acceptance criteria:** - Player tampil pada Scene. - Komponen fisika
dasar terpasang. - Player dapat dijadikan Prefab. - Tidak ada error
baru.

**Output:** Player GameObject dan Prefab dasar.

### TP-006 --- Implementasi Player movement

-   **Prioritas:** P0
-   **Estimasi:** 3--5 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-005
-   **Status:** Done

**Tujuan:** Memungkinkan pemain menggerakkan ikan ke empat arah
menggunakan keyboard.

**Panduan implementasi:** 1. Buat script `PlayerController.cs` di
`Assets/Scripts/Player/`. 2. Baca input WASD menggunakan Input Manager
(Old), misalnya melalui `Input.GetAxisRaw` dengan sumbu Horizontal dan
Vertical. 3. Normalisasi input diagonal agar kecepatan diagonal tidak
lebih besar daripada gerak horizontal/vertikal. 4. Terapkan gerakan
menggunakan pendekatan Rigidbody2D yang konsisten, misalnya
`Rigidbody2D.MovePosition` pada `FixedUpdate`. 5. Buat nilai kecepatan
sebagai field yang dapat diatur melalui Inspector. 6. Pastikan input
kosong membuat Player berhenti. 7. Hindari mengubah posisi Rigidbody2D
melalui beberapa metode sekaligus.

**Panduan Inspector:** - Pasang `PlayerController` pada Player. -
Hubungkan referensi Rigidbody2D melalui Inspector jika script
menggunakan serialized reference. - Atur kecepatan awal pada nilai yang
mudah diuji. - Pastikan sumbu Horizontal dan Vertical tersedia pada
Input Manager.

**Pengujian manual:** - Tekan W, A, S, D satu per satu. - Uji gerakan
diagonal. - Lepaskan tombol dan pastikan Player berhenti. - Pastikan
gerakan tidak semakin cepat saat beberapa tombol ditekan bersamaan.

**Acceptance criteria:** - WASD menggerakkan Player sesuai arah. -
Kecepatan diagonal konsisten. - Player berhenti ketika tidak ada
input. - Gerakan stabil dan tidak menghasilkan error.

**Output:** PlayerController dan gerakan dasar.

### TP-007 --- Implementasi arah hadap Player

-   **Prioritas:** P1
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-006
-   **Status:** Not Started

**Tujuan:** Membuat arah visual Player mengikuti arah gerakan.

**Panduan implementasi:** 1. Tentukan orientasi default sprite. 2.
Simpan arah gerak terakhir yang valid. 3. Saat Player bergerak ke
kiri/kanan, ubah orientasi visual sesuai arah tersebut. 4. Jika sprite
menggunakan flip, gunakan `SpriteRenderer.flipX` atau pendekatan visual
lain yang konsisten. 5. Jangan mengubah skala fisik Player secara tidak
sengaja saat membalik sprite. 6. Jika animasi belum tersedia, cukup
gunakan pembalikan sprite.

**Panduan Inspector:** - Pastikan referensi SpriteRenderer terhubung. -
Pastikan collider tidak ikut berubah bentuk saat sprite dibalik.

**Pengujian manual:** - Gerakkan Player ke kiri dan kanan. - Gerakkan ke
atas dan bawah. - Pastikan orientasi tidak berkedip atau berubah saat
input dilepas.

**Acceptance criteria:** - Arah hadap visual sesuai arah horizontal
gerakan. - Collider dan ukuran fisik tetap konsisten.

**Output:** Arah hadap Player.

### TP-008 --- Implementasi batas gerak Player

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Gameplay / AI & World
-   **Dependensi:** TP-006
-   **Status:** Not Started

**Tujuan:** Mencegah Player keluar dari arena.

**Panduan implementasi:** 1. Siapkan batas arena berupa dinding atau
collider pembatas. 2. Pastikan Player menggunakan Collider2D. 3. Gunakan
collision yang sesuai agar Player tertahan oleh dinding. 4. Periksa
apakah Rigidbody2D dan Collider2D tidak saling menembus karena
konfigurasi yang keliru. 5. Hindari solusi clamp posisi dan dinding
fisik yang saling bertentangan; gunakan satu pendekatan utama yang
konsisten.

**Panduan Inspector:** - Dinding: BoxCollider2D atau Collider2D lain
yang sesuai. - Player: Collider2D dan Rigidbody2D. - Periksa Layer
Collision Matrix bila objek tidak saling bertabrakan.

**Pengujian manual:** - Dorong Player ke setiap sisi arena. - Uji sudut
arena. - Pastikan Player tidak keluar atau tersangkut.

**Acceptance criteria:** - Player tidak dapat keluar dari area
permainan. - Tabrakan dengan dinding stabil.

**Output:** Sistem batas gerak Player.

------------------------------------------------------------------------

## Fase 3 --- Fish Entity System

**Target:** Minggu 1--3\
**Tujuan fase:** Menyediakan struktur data dan perilaku dasar untuk
berbagai jenis ikan.

### TP-009 --- Membuat struktur dasar Fish

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-002
-   **Status:** Not Started

**Tujuan:** Membuat komponen dasar yang dapat digunakan oleh berbagai
jenis ikan.

**Panduan implementasi:** 1. Buat script `Fish.cs` di
`Assets/Scripts/Fish/`. 2. Tentukan data dasar ikan, misalnya: -
`sizeLevel` untuk aturan ukuran. - nilai skor ketika dimakan. -
kecepatan gerak. - jenis/kategori ikan jika diperlukan. 3. Pisahkan data
gameplay dari ukuran visual sprite. 4. Gunakan field yang dapat
dikonfigurasi melalui Inspector untuk nilai yang memang perlu diubah
saat balancing. 5. Hindari membuat satu script terlalu besar yang
sekaligus menangani AI, UI, spawning, dan seluruh aturan game. 6.
Tentukan cara mengidentifikasi ikan yang dapat dimakan dan ikan
pemangsa.

**Panduan Inspector:** - Pasang komponen dasar pada prefab ikan. - Isi
nilai `sizeLevel` dan parameter awal. - Pastikan nilai ukuran tidak
bergantung pada `Transform.localScale`.

**Pengujian manual:** - Buat satu objek ikan sementara. - Periksa nilai
field melalui Inspector. - Pastikan perubahan nilai di Inspector terbaca
oleh komponen.

**Acceptance criteria:** - Komponen Fish dapat digunakan ulang. -
Atribut ukuran gameplay terpisah dari skala visual. - Parameter utama
dapat dikonfigurasi dan diuji.

**Output:** Komponen dasar Fish.

### TP-010 --- Membuat prefab Small Fish, Medium Fish, dan Predator

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-009
-   **Status:** Not Started

**Tujuan:** Menyediakan prefab untuk tiga kategori ikan non-player.

**Panduan implementasi:** 1. Buat GameObject untuk Small Fish. 2.
Tambahkan SpriteRenderer, Rigidbody2D, Collider2D, dan komponen Fish. 3.
Konfigurasikan `sizeLevel` sesuai hierarki ukuran yang disepakati. 4.
Jadikan prefab. 5. Ulangi untuk Medium Fish dan Predator. 6. Pastikan
setiap prefab memiliki nilai kecepatan, ukuran gameplay, dan nilai skor
yang sesuai. 7. Gunakan placeholder sprite terlebih dahulu jika aset
final belum tersedia.

**Panduan Inspector:** - Periksa SpriteRenderer, Rigidbody2D,
Collider2D, dan Fish. - Atur collider agar sesuai dengan bentuk objek. -
Pastikan nilai ukuran gameplay konsisten: Small Fish \< Medium Fish \<
Predator. Nilai Player ditentukan dalam skala yang sama.

**Pengujian manual:** - Tempatkan masing-masing prefab di Scene. -
Periksa komponen dan nilai Inspector. - Pastikan tidak ada prefab yang
kehilangan referensi.

**Acceptance criteria:** - Tiga prefab ikan tersedia. - Data ukuran
gameplay berbeda sesuai hierarki. - Setiap prefab memiliki komponen
dasar yang diperlukan.

**Output:** Prefab Small Fish, Medium Fish, dan Predator.

### TP-011 --- Implementasi konfigurasi ukuran dan aturan kategori ikan

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-009, TP-010
-   **Status:** Not Started

**Tujuan:** Menetapkan aturan perbandingan ukuran yang konsisten untuk
interaksi makan.

**Panduan implementasi:** 1. Tentukan rentang `sizeLevel` untuk Player
dan setiap kategori ikan. 2. Tentukan aturan bahwa entitas hanya dapat
memakan target yang ukuran gameplay-nya lebih kecil. 3. Tentukan aturan
khusus jika dua entitas memiliki ukuran sama: tidak dapat saling
memakan. 4. Buat fungsi terpusat untuk memeriksa kelayakan makan, bukan
menyalin kondisi berbeda ke banyak script. 5. Gunakan data ukuran
gameplay, bukan ukuran sprite atau jarak visual.

**Pengujian manual:** - Uji perbandingan Player dengan Small Fish. - Uji
Player dengan Medium Fish. - Uji Player dengan Predator. - Uji dua ikan
dengan ukuran sama.

**Acceptance criteria:** - Hasil perbandingan ukuran konsisten. -
Entitas berukuran sama tidak dapat saling memakan. - Aturan tidak
bergantung pada skala visual.

**Output:** Aturan perbandingan ukuran ikan.

### TP-012 --- Implementasi gerakan dasar ikan

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-010
-   **Status:** Not Started

**Tujuan:** Membuat ikan dapat bergerak tanpa input pemain.

**Panduan implementasi:** 1. Buat komponen gerak dasar untuk ikan. 2.
Tentukan arah dan kecepatan awal. 3. Buat perubahan arah sederhana dalam
interval tertentu atau saat mendekati batas arena. 4. Pastikan ikan
tidak terus bergerak keluar arena. 5. Pisahkan gerak dasar dari
keputusan AI agar perilaku dapat diperluas. 6. Pastikan gerak
menggunakan Rigidbody2D secara konsisten.

**Panduan Inspector:** - Hubungkan Rigidbody2D. - Atur kecepatan dan
interval perubahan arah. - Pastikan collider dan layer sesuai.

**Pengujian manual:** - Tempatkan beberapa ikan. - Jalankan Play Mode. -
Pastikan ikan bergerak dan tidak menghasilkan error.

**Acceptance criteria:** - Ikan dapat bergerak secara mandiri. -
Kecepatan dapat diatur. - Gerakan tidak menyebabkan ikan menembus batas
arena.

**Output:** Gerak dasar ikan.

------------------------------------------------------------------------

## Fase 4 --- Core Gameplay & Growth

**Target:** Minggu 2--3\
**Tujuan fase:** Mengimplementasikan interaksi makan, pertumbuhan, dan
skor sebagai inti permainan.

### TP-013 --- Implementasi deteksi interaksi makan

-   **Prioritas:** P0
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-006, TP-011, TP-012
-   **Status:** Not Started

**Tujuan:** Mendeteksi ketika Player atau ikan lain bersentuhan dengan
target yang dapat dimakan.

**Panduan implementasi:** 1. Tentukan pendekatan collision yang
digunakan, misalnya `OnTriggerEnter2D` atau collision biasa. 2. Pastikan
konfigurasi Collider2D mendukung pendekatan tersebut. 3. Saat terjadi
kontak, identifikasi entitas pemakan dan target. 4. Panggil aturan
ukuran dari TP-011. 5. Jika target lebih kecil dan aturan mengizinkan,
jalankan proses makan. 6. Jika target tidak memenuhi syarat, jangan
menghapus atau mengubah objek. 7. Cegah satu target diproses lebih dari
sekali.

**Panduan Inspector:** - Jika menggunakan trigger, aktifkan `Is Trigger`
pada collider yang sesuai. - Pastikan minimal salah satu objek memiliki
Rigidbody2D sesuai persyaratan event fisika Unity. - Periksa Layer
Collision Matrix.

**Pengujian manual:** - Player menyentuh Small Fish. - Player menyentuh
Predator. - Player menyentuh ikan dengan ukuran sama. - Pastikan hanya
interaksi yang valid menghasilkan proses makan.

**Acceptance criteria:** - Kontak terdeteksi dengan benar. - Aturan
ukuran diterapkan. - Target tidak diproses berulang kali.

**Output:** Sistem deteksi interaksi makan.

### TP-014 --- Implementasi proses ikan dimakan

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-013
-   **Status:** Not Started

**Tujuan:** Menghapus atau menonaktifkan ikan yang berhasil dimakan dan
meneruskan informasi hasil interaksi.

**Panduan implementasi:** 1. Buat satu jalur proses makan yang digunakan
oleh Player dan ikan AI. 2. Validasi bahwa target masih aktif dan belum
pernah diproses. 3. Ambil data target yang diperlukan, seperti nilai
skor atau kontribusi pertumbuhan. 4. Jalankan respons pemakan
(pertumbuhan/skor) melalui komponen atau manager yang sesuai. 5. Hapus
atau kembalikan target ke pool jika object pooling memang sudah
diterapkan. 6. Hindari pemanggilan Destroy dari banyak tempat untuk
target yang sama.

**Pengujian manual:** - Makan satu ikan yang valid. - Pastikan target
hilang satu kali. - Pastikan interaksi yang tidak valid tidak menghapus
target.

**Acceptance criteria:** - Target yang valid menghilang setelah
dimakan. - Target hanya diproses sekali. - Proses makan dapat digunakan
oleh beberapa jenis pemangsa.

**Output:** Alur proses makan yang konsisten.

### TP-015 --- Implementasi pertumbuhan Player

-   **Prioritas:** P0
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-014
-   **Status:** Not Started

**Tujuan:** Meningkatkan ukuran gameplay Player setelah berhasil memakan
ikan yang sesuai.

**Panduan implementasi:** 1. Tentukan variabel pertumbuhan Player yang
terpisah dari ukuran visual. 2. Tentukan kontribusi pertumbuhan dari
jenis ikan yang dimakan. 3. Perbarui nilai pertumbuhan setelah proses
makan berhasil. 4. Tentukan apakah pertumbuhan visual menggunakan skala
sprite atau sprite/animasi berbeda. 5. Pastikan perubahan visual tidak
mengubah aturan `sizeLevel` secara tidak sengaja. 6. Tentukan cara
pertumbuhan memengaruhi ukuran gameplay Player, misalnya melalui level
atau ambang pertumbuhan. 7. Buat nilai target pertumbuhan yang dapat
dikonfigurasi untuk Objective Mode.

**Panduan Inspector:** - Atur nilai awal pertumbuhan dan target melalui
komponen konfigurasi yang sesuai. - Periksa collider setelah perubahan
visual; collider harus tetap proporsional dan tidak terlalu besar/kecil.

**Pengujian manual:** - Makan ikan kecil. - Pastikan nilai pertumbuhan
bertambah. - Uji beberapa kali sampai melewati ambang level. - Pastikan
Player tidak langsung menjadi besar hanya karena skala visual diubah.

**Acceptance criteria:** - Pertumbuhan bertambah hanya setelah makan
yang valid. - Nilai pertumbuhan dapat diperiksa. - Ukuran gameplay
diperbarui berdasarkan aturan yang disepakati. - Tampilan dan collider
tetap masuk akal.

**Output:** Sistem pertumbuhan Player.

### TP-016 --- Implementasi skor

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-014
-   **Status:** Not Started

**Tujuan:** Memberikan skor ketika entitas berhasil memakan target.

**Panduan implementasi:** 1. Tentukan sumber nilai skor, misalnya nilai
pada prefab ikan. 2. Buat penyimpanan skor sesi. 3. Tambahkan skor hanya
setelah proses makan tervalidasi. 4. Cegah skor bertambah lebih dari
sekali untuk target yang sama. 5. Sediakan cara membaca skor oleh UI dan
Game Manager. 6. Jangan menggunakan skor sebagai pengganti nilai
pertumbuhan; keduanya memiliki fungsi berbeda.

**Pengujian manual:** - Catat skor awal. - Makan satu ikan. - Pastikan
skor bertambah sesuai nilai target. - Uji kontak tidak valid dan
pastikan skor tidak bertambah.

**Acceptance criteria:** - Skor bertambah sesuai aturan. - Skor tidak
bertambah dari interaksi tidak valid. - Skor tersimpan selama satu sesi
permainan.

**Output:** Sistem skor sesi.

### TP-017 --- Implementasi kondisi Player dimangsa

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-013, TP-011
-   **Status:** Not Started

**Tujuan:** Mengakhiri sesi ketika Player dimakan entitas yang lebih
besar.

**Panduan implementasi:** 1. Gunakan aturan ukuran yang sama dengan
sistem makan. 2. Jika entitas pemangsa lebih besar daripada Player,
kirim sinyal Player kalah ke Game Manager. 3. Pastikan proses kematian
hanya terjadi satu kali. 4. Hentikan atau nonaktifkan kontrol Player
setelah kalah. 5. Siapkan titik integrasi untuk animasi/efek kematian
jika tersedia.

**Pengujian manual:** - Player menyentuh Predator yang lebih besar. -
Player menyentuh ikan yang lebih kecil. - Pastikan hanya kondisi pertama
yang menyebabkan Player kalah.

**Acceptance criteria:** - Player kalah saat dimakan pemangsa yang lebih
besar. - Player tidak kalah saat menyentuh ikan yang lebih kecil. -
Event kematian hanya diproses sekali.

**Output:** Kondisi kalah Player.

------------------------------------------------------------------------

## Fase 5 --- AI Behavior & Fish Spawning

**Target:** Minggu 3\
**Tujuan fase:** Memberikan perilaku sederhana pada ikan dan menjaga
jumlah ikan di arena.

### TP-018 --- AI Small Fish: wander dan flee

-   **Prioritas:** P0
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-012, TP-013
-   **Status:** Not Started

**Tujuan:** Small Fish bergerak bebas dan berusaha menjauh ketika ada
ancaman yang lebih besar.

**Panduan implementasi:** 1. Buat script perilaku khusus atau komponen
perilaku yang dapat digunakan ulang. 2. Saat tidak ada ancaman, gunakan
gerak wander sederhana. 3. Deteksi entitas pemangsa dalam radius
tertentu. 4. Jika ancaman terdeteksi, hitung arah menjauh dari ancaman.
5. Kembali ke wander ketika ancaman tidak lagi terdeteksi. 6. Batasi
gerak agar tetap berada di arena. 7. Hindari membuat AI melakukan
pencarian semua objek setiap frame jika jumlah ikan bertambah; gunakan
frekuensi pemeriksaan yang wajar.

**Panduan Inspector:** - Atur detection radius, kecepatan wander, dan
kecepatan flee. - Hubungkan referensi Rigidbody2D dan komponen yang
dibutuhkan.

**Pengujian manual:** - Jalankan tanpa Player di dekat ikan. - Dekatkan
Player atau predator. - Pastikan ikan mengubah arah menjauh. - Pastikan
ikan kembali bergerak normal ketika ancaman menjauh.

**Acceptance criteria:** - Small Fish dapat wander. - Small Fish
bereaksi menjauh dari ancaman. - Perilaku tidak menyebabkan ikan keluar
arena.

**Output:** AI Small Fish.

### TP-019 --- AI Medium Fish: wander dan chase target kecil

-   **Prioritas:** P1
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-012, TP-013, TP-011
-   **Status:** Not Started

**Tujuan:** Medium Fish bergerak bebas dan mengejar ikan yang lebih
kecil ketika target berada dalam jangkauan.

**Panduan implementasi:** 1. Gunakan wander sebagai perilaku default. 2.
Deteksi ikan yang ukurannya lebih kecil dalam radius tertentu. 3. Pilih
target yang valid. 4. Bergerak ke arah target. 5. Batalkan pengejaran
jika target hilang, keluar jangkauan, atau tidak lagi valid. 6. Pastikan
Medium Fish tidak mengejar target yang lebih besar atau setara. 7.
Setelah target berhasil dimakan atau tidak tersedia, kembali ke wander.

**Panduan Inspector:** - Atur detection radius, chase speed, dan wander
speed. - Pastikan nilai `sizeLevel` pada prefab sudah benar.

**Pengujian manual:** - Tempatkan Small Fish dekat Medium Fish. -
Pastikan Medium Fish mengejar. - Tempatkan ikan yang lebih besar dan
pastikan tidak dikejar. - Pastikan Medium Fish kembali wander setelah
target hilang.

**Acceptance criteria:** - Medium Fish mengejar target yang lebih
kecil. - Target yang tidak valid diabaikan. - Perilaku kembali ke wander
dengan benar.

**Output:** AI Medium Fish.

### TP-020 --- AI Predator: patrol/wander dan chase Player

-   **Prioritas:** P0
-   **Estimasi:** 3--5 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-012, TP-013, TP-017
-   **Status:** Not Started

**Tujuan:** Membuat Predator menjadi ancaman utama bagi Player.

**Panduan implementasi:** 1. Gunakan wander atau patrol sederhana
sebagai perilaku default. 2. Deteksi Player dalam radius tertentu. 3.
Pastikan Predator hanya mengejar Player jika aturan ukuran mengizinkan.
4. Bergerak menuju Player selama Player berada dalam jangkauan. 5.
Hentikan pengejaran ketika Player keluar dari radius atau kondisi
permainan berakhir. 6. Pastikan gerakan tidak menembus batas arena. 7.
Atur kecepatan Predator agar ancaman terasa tetapi masih dapat
dihindari.

**Panduan Inspector:** - Atur detection radius, patrol/wander speed, dan
chase speed. - Periksa referensi target dan Rigidbody2D.

**Pengujian manual:** - Jauhkan Player dari Predator. - Dekatkan Player
ke radius deteksi. - Keluar kembali dari radius. - Pastikan Predator
mengejar dan berhenti sesuai aturan.

**Acceptance criteria:** - Predator bergerak saat tidak mendeteksi
Player. - Predator mengejar Player dalam radius. - Pengejaran berhenti
saat kondisi tidak terpenuhi. - Predator dapat memangsa Player sesuai
aturan ukuran.

**Output:** AI Predator.

### TP-021 --- Implementasi Fish Spawner

-   **Prioritas:** P0
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-010, TP-008, TP-018
-   **Status:** Not Started

**Tujuan:** Menghasilkan ikan secara otomatis di dalam arena.

**Panduan implementasi:** 1. Buat `FishSpawner.cs`. 2. Siapkan referensi
prefab ikan yang dapat di-spawn. 3. Tentukan area spawn yang berada di
dalam batas arena. 4. Tentukan interval spawn dan jumlah maksimum ikan
aktif. 5. Pilih jenis ikan berdasarkan konfigurasi sederhana. 6.
Pastikan ikan tidak muncul di dalam dinding atau menumpuk pada satu
posisi. 7. Pastikan jumlah ikan tidak terus bertambah tanpa batas. 8.
Jika waktu memungkinkan, pisahkan konfigurasi spawn dari script melalui
data/field Inspector.

**Panduan Inspector:** - Hubungkan prefab Small Fish, Medium Fish, dan
Predator. - Atur batas jumlah ikan, interval, dan area spawn. - Pastikan
referensi prefab tidak kosong.

**Pengujian manual:** - Jalankan Play Mode. - Amati ikan muncul secara
berkala. - Pastikan jumlah ikan tidak melewati batas. - Pastikan spawn
terjadi di area yang valid.

**Acceptance criteria:** - Ikan muncul otomatis. - Jenis ikan yang
di-spawn sesuai konfigurasi. - Jumlah ikan dibatasi. - Spawn tidak
terjadi di luar arena.

**Output:** Sistem Fish Spawner.

------------------------------------------------------------------------

## Fase 6 --- Game Flow & Game Modes

**Target:** Minggu 3--4\
**Tujuan fase:** Mengelola alur sesi, kondisi menang/kalah, dan dua mode
permainan.

### TP-022 --- Membuat Game Manager

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** Gameplay / UI & Integration
-   **Dependensi:** TP-016, TP-017
-   **Status:** Not Started

**Tujuan:** Menjadi pusat pengelolaan status permainan.

**Panduan implementasi:** 1. Buat `GameManager.cs`. 2. Tentukan state
dasar, misalnya Main Menu, Playing, Paused, Victory, dan Game Over. 3.
Sediakan fungsi untuk memulai sesi, pause, resume, menang, dan kalah. 4.
Pastikan perubahan state tidak terjadi berulang kali secara tidak
sengaja. 5. Jadikan Game Manager sebagai penghubung antara sistem
gameplay dan UI. 6. Hindari memasukkan seluruh logika Player, AI, dan UI
ke dalam satu script Game Manager.

**Panduan Inspector:** - Buat GameObject khusus GameManager. - Pasang
script. - Hubungkan referensi komponen yang memang dibutuhkan. - Hindari
membuat beberapa GameManager aktif tanpa alasan.

**Pengujian manual:** - Jalankan Scene. - Periksa state awal. - Panggil
perubahan state melalui alur uji sederhana. - Pastikan tidak ada
transisi yang tidak diinginkan.

**Acceptance criteria:** - Status permainan terpusat. - Fungsi utama
dapat dipanggil oleh sistem lain. - Tidak ada transisi state ganda.

**Output:** GameManager.

### TP-023 --- Implementasi Objective Mode

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-015, TP-022
-   **Status:** Not Started

**Tujuan:** Menyelesaikan permainan ketika Player mencapai target
pertumbuhan.

**Panduan implementasi:** 1. Tentukan target pertumbuhan untuk Objective
Mode. 2. Baca nilai pertumbuhan Player dari sistem Growth. 3. Periksa
kondisi target setelah pertumbuhan berhasil diperbarui. 4. Jika target
tercapai, kirim state Victory ke Game Manager. 5. Pastikan kondisi
menang tidak dipicu hanya karena skor tinggi. 6. Pastikan kondisi menang
dan kalah tidak dapat aktif bersamaan. 7. Buat target dapat diatur
melalui Inspector atau konfigurasi mode.

**Pengujian manual:** - Mulai Objective Mode. - Makan ikan sampai target
belum tercapai. - Pastikan permainan masih berlangsung. - Capai target
pertumbuhan. - Pastikan state Victory aktif.

**Acceptance criteria:** - Objective Mode hanya menang berdasarkan
target pertumbuhan. - Target dapat dikonfigurasi. - Kondisi kemenangan
diproses satu kali.

**Output:** Objective Mode.

### TP-024 --- Implementasi Endless Mode

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay
-   **Dependensi:** TP-016, TP-017, TP-022
-   **Status:** Not Started

**Tujuan:** Membuat mode permainan tanpa target pertumbuhan akhir; sesi
berakhir ketika Player mati.

**Panduan implementasi:** 1. Mulai sesi Endless Mode. 2. Aktifkan sistem
skor dan survival. 3. Jangan mengaktifkan kondisi Victory berdasarkan
target pertumbuhan. 4. Akhiri sesi saat Player dimangsa. 5. Simpan atau
tampilkan skor akhir. 6. Pastikan sistem pertumbuhan tetap dapat
digunakan sebagai bagian dari gameplay, tetapi bukan syarat menang.

**Pengujian manual:** - Mulai Endless Mode. - Makan beberapa ikan dan
pastikan skor bertambah. - Pastikan tidak muncul Victory hanya karena
pertumbuhan. - Biarkan Player dimangsa dan pastikan sesi berakhir.

**Acceptance criteria:** - Endless Mode berlangsung sampai Player
kalah. - Skor akhir tercatat. - Tidak ada kondisi kemenangan Objective
Mode yang aktif di mode ini.

**Output:** Endless Mode.

### TP-025 --- Implementasi pause, resume, dan restart

-   **Prioritas:** P1
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-022
-   **Status:** Not Started

**Tujuan:** Memberikan kontrol dasar terhadap sesi permainan.

**Panduan implementasi:** 1. Buat fungsi Pause dan Resume. 2. Tentukan
cara membuka Pause Menu, misalnya tombol Escape. 3. Gunakan pengaturan
waktu game secara konsisten. 4. Buat fungsi restart sesi. 5. Pastikan
restart mengatur ulang skor, pertumbuhan, status Player, dan entitas
sesi sesuai kebutuhan. 6. Pastikan tombol Pause tidak dapat mengaktifkan
pause berulang secara keliru.

**Pengujian manual:** - Pause ketika permainan berlangsung. - Pastikan
gerakan dan timer berhenti. - Resume dan pastikan permainan berjalan
kembali. - Restart dan pastikan state sesi kembali ke awal.

**Acceptance criteria:** - Pause dan Resume bekerja. - Restart memulai
sesi baru dengan data sesi yang benar. - Tidak ada state lama yang
tertinggal.

**Output:** Pause, Resume, dan Restart.

------------------------------------------------------------------------

## Fase 7 --- UI, Arena & Visual Assets

**Target:** Minggu 4\
**Tujuan fase:** Membuat permainan mudah dipahami dan memiliki tampilan
yang cukup lengkap.

### TP-026 --- Membuat HUD gameplay

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-015, TP-016, TP-022
-   **Status:** Not Started

**Tujuan:** Menampilkan informasi utama selama permainan.

**Panduan implementasi:** 1. Buat Canvas untuk HUD. 2. Tambahkan
tampilan skor. 3. Tambahkan indikator pertumbuhan Player. 4. Jika
diperlukan, tampilkan progress menuju target Objective Mode. 5. Buat
referensi UI menerima pembaruan dari sistem skor dan pertumbuhan. 6.
Pastikan UI tidak menghitung ulang aturan gameplay sendiri. 7. Pastikan
informasi tetap terbaca pada resolusi target.

**Panduan Inspector:** - Canvas: Render Mode Screen Space - Overlay. -
Gunakan Canvas Scaler dengan pengaturan yang sesuai untuk berbagai
resolusi. - Atur Anchor UI agar posisi elemen stabil.

**Pengujian manual:** - Jalankan permainan. - Makan ikan. - Pastikan
skor dan indikator pertumbuhan diperbarui. - Uji pada resolusi berbeda
jika tersedia.

**Acceptance criteria:** - HUD menampilkan skor dan pertumbuhan. - Data
UI sesuai dengan data gameplay. - Tampilan tetap terbaca.

**Output:** HUD gameplay.

### TP-027 --- Membuat Main Menu dan pemilihan mode

-   **Prioritas:** P0
-   **Estimasi:** 3--4 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-022, TP-023, TP-024
-   **Status:** Not Started

**Tujuan:** Memberikan titik masuk permainan dan pemilihan mode.

**Panduan implementasi:** 1. Buat tampilan Main Menu. 2. Tambahkan judul
Tiny Predators. 3. Tambahkan tombol Objective Mode. 4. Tambahkan tombol
Endless Mode. 5. Tambahkan tombol Exit jika sesuai target build. 6.
Pastikan pemilihan mode mengirim konfigurasi yang benar ke Game Manager.
7. Tentukan apakah menu berada pada Scene terpisah atau satu Scene.
Pilih pendekatan yang paling sederhana dan stabil untuk proyek enam
minggu.

**Panduan Inspector:** - Hubungkan event tombol melalui script atau
Unity UI Button OnClick. - Periksa referensi Game Manager. - Pastikan
tombol tidak memiliki event ganda.

**Pengujian manual:** - Jalankan dari Main Menu. - Pilih kedua mode
secara bergantian. - Pastikan mode yang dimulai sesuai pilihan.

**Acceptance criteria:** - Main Menu tampil. - Kedua mode dapat
dipilih. - Tombol menjalankan fungsi yang benar.

**Output:** Main Menu dan pemilihan mode.

### TP-028 --- Membuat layar Victory dan Game Over

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-022, TP-023, TP-024
-   **Status:** Not Started

**Tujuan:** Memberikan umpan balik yang jelas ketika sesi berakhir.

**Panduan implementasi:** 1. Buat panel Victory untuk Objective Mode. 2.
Buat panel Game Over untuk kondisi Player kalah. 3. Tampilkan skor akhir
jika relevan. 4. Tambahkan tombol Restart. 5. Tambahkan tombol kembali
ke Main Menu. 6. Pastikan panel yang tidak sesuai kondisi tetap
tersembunyi. 7. Pastikan input gameplay tidak terus berjalan setelah
sesi berakhir.

**Pengujian manual:** - Capai target Objective Mode. - Pastikan Victory
tampil. - Kalah di kedua mode. - Pastikan Game Over tampil. - Uji
Restart dan Main Menu.

**Acceptance criteria:** - Panel akhir sesuai kondisi permainan. - Skor
akhir ditampilkan dengan benar. - Tombol navigasi bekerja.

**Output:** UI Victory dan Game Over.

### TP-029 --- Membuat arena dan batas lingkungan

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-008
-   **Status:** Not Started

**Tujuan:** Membuat satu arena bawah laut yang menjadi area permainan.

**Panduan implementasi:** 1. Buat background arena. 2. Tambahkan elemen
dekoratif yang tidak mengganggu gameplay. 3. Buat dinding/batas arena
menggunakan Collider2D. 4. Pastikan batas arena cukup luas untuk
pergerakan ikan. 5. Atur sorting layer agar Player dan ikan terlihat di
atas background. 6. Pastikan titik spawn berada di dalam area. 7.
Gunakan aset placeholder jika aset final belum tersedia.

**Panduan Inspector:** - SpriteRenderer: Sorting Layer dan Order in
Layer. - Collider2D: posisi dan ukuran dinding. - Kamera: pastikan
seluruh area permainan terlihat.

**Pengujian manual:** - Jalankan Play Mode. - Periksa seluruh sisi
arena. - Pastikan Player dan ikan tidak keluar area. - Pastikan
background tidak menutupi objek gameplay.

**Acceptance criteria:** - Satu arena dapat dimainkan. - Batas arena
berfungsi. - Objek gameplay terlihat jelas.

**Output:** Arena gameplay.

### TP-030 --- Integrasi aset visual dan animasi dasar

-   **Prioritas:** P1
-   **Estimasi:** 3--6 jam
-   **Peran yang disarankan:** UI & Integration / AI & World
-   **Dependensi:** TP-005, TP-010, TP-029
-   **Status:** Not Started

**Tujuan:** Mengganti placeholder dengan aset visual yang sesuai
identitas game.

**Panduan implementasi:** 1. Pilih atau buat sprite Player, Small Fish,
Medium Fish, Predator, dan environment. 2. Periksa lisensi dan ketentuan
penggunaan aset gratis. 3. Impor aset ke folder yang sesuai. 4. Atur
Texture Type, Pixels Per Unit, Filter Mode, dan Compression sesuai
karakter aset. 5. Atur pivot dan sorting layer. 6. Jika tersedia waktu,
buat animasi gerak/berenang sederhana. 7. Pastikan perubahan sprite
tidak merusak collider atau referensi prefab.

**Panduan Inspector:** - Sprite Import Settings. - SpriteRenderer. -
Animator dan Animation Clip jika animasi digunakan. - Periksa prefab
setelah mengganti sprite.

**Pengujian manual:** - Jalankan semua prefab. - Pastikan sprite tampil
tajam dan tidak terdistorsi. - Pastikan animasi tidak mengubah posisi
atau ukuran objek secara tidak sengaja.

**Acceptance criteria:** - Aset utama sudah menggunakan visual yang
konsisten. - Lisensi aset eksternal dapat ditelusuri. - Prefab dan
collider tetap berfungsi.

**Output:** Aset visual terintegrasi.

------------------------------------------------------------------------

## Fase 8 --- Integration & Functional Testing

**Target:** Minggu 4--5\
**Tujuan fase:** Menggabungkan seluruh sistem dan memastikan gameplay
berjalan dari awal hingga akhir.

### TP-031 --- Integrasi seluruh sistem gameplay

-   **Prioritas:** P0
-   **Estimasi:** 3--5 jam
-   **Peran yang disarankan:** Seluruh anggota
-   **Dependensi:** TP-013 sampai TP-030
-   **Status:** Not Started

**Tujuan:** Memastikan seluruh komponen game bekerja sebagai satu alur.

**Panduan implementasi:** 1. Integrasikan Player, Fish, AI, Spawner,
Growth, Score, dan Game Manager. 2. Periksa seluruh referensi Inspector
pada Scene dan prefab. 3. Periksa urutan inisialisasi dan komunikasi
antar-komponen. 4. Pastikan hanya ada satu sumber kebenaran untuk skor,
pertumbuhan, dan status game. 5. Perbaiki konflik integrasi melalui
koordinasi pemilik file. 6. Hindari refactor besar ketika fitur inti
belum stabil.

**Pengujian manual:** - Mulai dari Main Menu. - Pilih mode. - Mainkan
beberapa menit. - Uji makan, pertumbuhan, skor, AI, kondisi
kalah/menang. - Uji restart dan kembali ke menu.

**Acceptance criteria:** - Seluruh sistem utama terhubung. - Tidak ada
referensi penting yang hilang. - Alur permainan dapat diselesaikan.

**Output:** Build internal terintegrasi.

### TP-032 --- Pengujian aturan makan dan pertumbuhan

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** Gameplay / QA
-   **Dependensi:** TP-031
-   **Status:** Not Started

**Tujuan:** Memastikan aturan ukuran, skor, dan pertumbuhan tidak saling
bertentangan.

**Skenario uji minimum:** 1. Player memakan Small Fish. 2. Player
mencoba memakan Medium Fish saat masih lebih kecil. 3. Player mencoba
memakan Predator. 4. Player memakan target setelah mencapai ukuran yang
memadai. 5. Dua entitas berukuran sama bersentuhan. 6. Satu target
bersentuhan dengan pemangsa lebih dari sekali. 7. Target sudah dimakan
tetapi event collision terpanggil kembali.

**Acceptance criteria:** - Hanya target yang lebih kecil yang dapat
dimakan. - Skor dan pertumbuhan hanya bertambah satu kali per target. -
Aturan ukuran tetap benar setelah Player tumbuh.

**Output:** Catatan hasil pengujian core gameplay dan daftar bug.

### TP-033 --- Pengujian AI dan spawning

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** AI & World / QA
-   **Dependensi:** TP-031
-   **Status:** Not Started

**Tujuan:** Memastikan perilaku ikan dan spawning stabil.

**Skenario uji minimum:** 1. Small Fish wander. 2. Small Fish flee dari
ancaman. 3. Medium Fish mengejar target lebih kecil. 4. Predator
mengejar Player dalam radius. 5. Predator berhenti mengejar saat Player
keluar radius. 6. Fish Spawner menghasilkan ikan. 7. Jumlah ikan tidak
melewati batas maksimum. 8. Ikan tidak muncul di luar arena atau di
dalam dinding.

**Acceptance criteria:** - Perilaku AI sesuai jenis ikan. - Spawner
tidak menghasilkan jumlah objek tanpa batas. - Tidak ada error runtime
yang belum ditangani.

**Output:** Catatan hasil pengujian AI dan spawning.

### TP-034 --- Pengujian dua mode permainan dan UI

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** UI & Integration / QA
-   **Dependensi:** TP-031
-   **Status:** Not Started

**Tujuan:** Memastikan alur Objective Mode dan Endless Mode berbeda
sesuai desain.

**Skenario uji minimum:** 1. Objective Mode dimulai dari Main Menu. 2.
Pertumbuhan belum mencapai target dan permainan berlanjut. 3.
Pertumbuhan mencapai target dan Victory muncul. 4. Endless Mode dimulai
dari Main Menu. 5. Pertumbuhan tidak memicu Victory di Endless Mode. 6.
Player kalah dan Game Over muncul. 7. Restart memulai sesi baru. 8.
Kembali ke Main Menu bekerja. 9. Pause dan Resume bekerja jika sudah
diimplementasikan.

**Acceptance criteria:** - Kedua mode mengikuti aturan masing-masing. -
Panel UI sesuai status game. - Restart tidak membawa skor atau
pertumbuhan dari sesi sebelumnya.

**Output:** Catatan hasil pengujian game flow dan UI.

### TP-035 --- Pengujian integrasi, bug fixing, dan regresi

-   **Prioritas:** P0
-   **Estimasi:** 4--6 jam
-   **Peran yang disarankan:** Seluruh anggota
-   **Dependensi:** TP-032, TP-033, TP-034
-   **Status:** Not Started

**Tujuan:** Memperbaiki bug yang ditemukan dan memastikan perbaikan
tidak merusak fitur lain.

**Panduan implementasi:** 1. Kumpulkan bug dari seluruh skenario uji. 2.
Kelompokkan berdasarkan dampak: blocker, major, minor. 3. Perbaiki bug
blocker terlebih dahulu. 4. Setelah setiap perbaikan, ulangi skenario
uji terkait. 5. Jalankan regression test pada fitur yang berhubungan. 6.
Jangan menambahkan fitur baru ketika masih ada bug blocker. 7. Catat bug
yang belum selesai beserta dampak dan workaround jika ada.

**Acceptance criteria:** - Tidak ada bug blocker yang diketahui. - Fitur
P0 lulus pengujian. - Bug major yang tersisa memiliki keputusan
penanganan dari tim.

**Output:** Daftar bug terbaru dan build internal yang stabil.

------------------------------------------------------------------------

## Fase 9 --- Polish, Balancing & Optimization

**Target:** Minggu 5\
**Tujuan fase:** Meningkatkan kualitas permainan tanpa mengambil risiko
terhadap fitur inti.

### TP-036 --- Balancing gameplay

-   **Prioritas:** P1
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** Gameplay / AI & World
-   **Dependensi:** TP-035
-   **Status:** Not Started

**Tujuan:** Menyesuaikan kesulitan dan tempo permainan.

**Panduan implementasi:** 1. Uji kecepatan Player dan setiap jenis ikan.
2. Sesuaikan radius deteksi AI. 3. Sesuaikan interval dan jumlah
maksimum spawn. 4. Sesuaikan nilai pertumbuhan dan skor. 5. Sesuaikan
target pertumbuhan Objective Mode. 6. Pastikan pemain memiliki
kesempatan untuk menghindari Predator. 7. Lakukan perubahan bertahap dan
catat nilai sebelum/sesudah.

**Acceptance criteria:** - Objective Mode dapat diselesaikan dengan
tingkat kesulitan yang wajar. - Endless Mode tetap menantang. - Tidak
ada perubahan balancing yang merusak aturan ukuran.

**Output:** Parameter gameplay yang sudah diseimbangkan.

### TP-037 --- Audio dan efek visual dasar

-   **Prioritas:** P2
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-035
-   **Status:** Not Started

**Tujuan:** Menambahkan umpan balik audiovisual pada aksi penting.

**Panduan implementasi:** 1. Tambahkan suara makan, kalah, dan/atau
kemenangan jika aset tersedia. 2. Tambahkan efek visual sederhana saat
ikan dimakan atau Player tumbuh. 3. Atur volume dan durasi agar tidak
mengganggu. 4. Pastikan efek tidak menambah beban berlebihan. 5. Jika
waktu terbatas, prioritaskan efek makan dan transisi kondisi akhir.

**Pengujian manual:** - Uji setiap efek pada kondisi yang tepat. -
Pastikan efek tidak dipicu berkali-kali dari satu event.

**Acceptance criteria:** - Efek yang dipilih berfungsi. - Efek tidak
mengganggu gameplay. - Tidak ada error karena referensi audio atau
visual yang hilang.

**Output:** Audio dan efek visual dasar.

### TP-038 --- Optimasi performa dasar

-   **Prioritas:** P1
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** AI & World / UI & Integration
-   **Dependensi:** TP-035
-   **Status:** Not Started

**Tujuan:** Menjaga game tetap responsif pada target PC.

**Panduan implementasi:** 1. Uji game dengan jumlah ikan mendekati batas
maksimum. 2. Amati penggunaan CPU dan performa melalui Profiler bila
diperlukan. 3. Hindari pencarian objek global setiap frame. 4. Kurangi
operasi alokasi yang tidak diperlukan di `Update`. 5. Pastikan jumlah
spawn dibatasi. 6. Pertimbangkan object pooling hanya jika pengujian
menunjukkan Instantiate/Destroy menjadi masalah. 7. Jangan melakukan
optimasi kompleks tanpa bukti bottleneck.

**Acceptance criteria:** - Game berjalan stabil pada skenario jumlah
ikan maksimum yang direncanakan. - Tidak ada penurunan performa yang
mengganggu. - Tidak ada optimasi berisiko yang merusak sistem.

**Output:** Hasil pemeriksaan dan perbaikan performa dasar.

### TP-039 --- Fitur opsional: Boids atau perilaku ikan tambahan

-   **Prioritas:** P3
-   **Estimasi:** 3--6 jam
-   **Peran yang disarankan:** AI & World
-   **Dependensi:** TP-035
-   **Status:** Not Started

**Tujuan:** Menambah variasi gerak ikan jika seluruh fitur wajib telah
stabil.

**Panduan implementasi:** 1. Pastikan seluruh task P0 selesai. 2.
Tentukan apakah perilaku kelompok ikan benar-benar meningkatkan
gameplay. 3. Jika ya, buat prototipe sederhana dengan separation,
alignment, dan cohesion. 4. Batasi jumlah ikan yang menggunakan perilaku
tersebut. 5. Bandingkan hasil dengan AI sederhana. 6. Hentikan pekerjaan
jika mengancam target build enam minggu.

**Acceptance criteria:** - Fitur hanya diintegrasikan jika stabil dan
tidak mengganggu fitur inti. - Jika tidak selesai, fitur boleh
dikeluarkan dari scope versi awal.

**Output:** Boids opsional atau keputusan untuk tidak memasukkannya.

------------------------------------------------------------------------

## Fase 10 --- Final Build & Delivery

**Target:** Minggu 6\
**Tujuan fase:** Menghasilkan build Windows yang dapat dimainkan dan
menyiapkan seluruh bahan pengumpulan.

### TP-040 --- Persiapan Build Settings

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** UI & Integration
-   **Dependensi:** TP-035
-   **Status:** Not Started

**Tujuan:** Menyiapkan konfigurasi build final.

**Panduan implementasi:** 1. Buka `File > Build Profiles` atau menu
build yang tersedia pada versi Unity. 2. Pilih target
Windows/Standalone. 3. Pastikan Scene yang dibutuhkan masuk dalam daftar
Scene untuk build. 4. Atur resolusi awal dan mode tampilan. 5. Periksa
Player Settings yang relevan. 6. Pastikan tidak ada Scene uji yang tidak
diperlukan. 7. Jangan mengubah konfigurasi build tanpa mencatat
perubahan.

**Pengujian manual:** - Periksa daftar Scene. - Pastikan platform target
Windows. - Pastikan konfigurasi tidak menghasilkan error.

**Acceptance criteria:** - Build target Windows siap. - Scene utama
masuk dalam konfigurasi build. - Tidak ada konfigurasi penting yang
tertinggal.

**Output:** Build configuration siap.

### TP-041 --- Membuat dan menguji Windows Build

-   **Prioritas:** P0
-   **Estimasi:** 2--4 jam
-   **Peran yang disarankan:** UI & Integration / QA
-   **Dependensi:** TP-040
-   **Status:** Not Started

**Tujuan:** Menghasilkan executable game dan memeriksa game di luar
Unity Editor.

**Panduan implementasi:** 1. Buat build Windows ke folder output yang
disepakati. 2. Jalankan executable hasil build. 3. Uji Main Menu,
Objective Mode, Endless Mode, gameplay, dan kondisi akhir. 4. Periksa
resolusi, input, audio, dan tampilan. 5. Periksa log jika build
mengalami masalah. 6. Perbaiki bug blocker dan buat build ulang bila
diperlukan.

**Acceptance criteria:** - Build dapat dijalankan di Windows. - Fitur
inti bekerja di luar Editor. - Tidak ada crash atau bug blocker yang
diketahui.

**Output:** Windows build final.

### TP-042 --- Dokumentasi dan penyiapan pengumpulan

-   **Prioritas:** P0
-   **Estimasi:** 2--3 jam
-   **Peran yang disarankan:** UI & Integration / Seluruh anggota
-   **Dependensi:** TP-041
-   **Status:** Not Started

**Tujuan:** Menyiapkan materi yang dibutuhkan untuk demonstrasi dan
pengumpulan tugas.

**Panduan implementasi:** 1. Perbarui README dengan deskripsi game,
kontrol, cara menjalankan, dan informasi tim. 2. Catat versi Unity yang
digunakan. 3. Catat sumber aset eksternal dan lisensinya. 4. Siapkan
screenshot atau video singkat gameplay jika diminta. 5. Pastikan
repository memiliki struktur yang rapi. 6. Pastikan file build dan
dokumentasi berada di lokasi pengumpulan yang disepakati. 7. Periksa
kembali apakah dosen meminta format atau artefak khusus.

**Acceptance criteria:** - README dapat dipahami. - Build dan
dokumentasi tersedia. - Sumber aset dapat ditelusuri. - Materi
demonstrasi siap.

**Output:** Paket pengumpulan Tiny Predators.

### TP-043 --- Final review dan penutupan proyek

-   **Prioritas:** P0
-   **Estimasi:** 1--2 jam
-   **Peran yang disarankan:** Seluruh anggota
-   **Dependensi:** TP-042
-   **Status:** Not Started

**Tujuan:** Memastikan hasil akhir sesuai scope dan siap
didemonstrasikan.

**Panduan implementasi:** 1. Jalankan build final dari awal sampai
akhir. 2. Pastikan Objective Mode dapat dimenangkan. 3. Pastikan Endless
Mode berakhir ketika Player kalah. 4. Pastikan kontrol, skor,
pertumbuhan, AI, dan UI berfungsi. 5. Pastikan tidak ada aset yang
hilang. 6. Periksa repository dan dokumentasi. 7. Catat keterbatasan
yang masih ada secara jujur.

**Acceptance criteria:** - Game dapat dimainkan dari awal hingga
akhir. - Kedua mode berfungsi. - Tidak ada bug blocker yang diketahui. -
Seluruh artefak pengumpulan tersedia.

**Output:** Proyek Tiny Predators siap didemonstrasikan dan dikumpulkan.

------------------------------------------------------------------------

## 5. Ringkasan Dependensi Utama

Diagram berikut menunjukkan alur dependensi tingkat tinggi. Tidak semua
task harus dikerjakan secara berurutan; task paralel diperbolehkan jika
dependensi teknisnya sudah terpenuhi.

``` mermaid
flowchart TD
    A[Project Setup: TP-001–004]
    B[Player System: TP-005–008]
    C[Fish Entity: TP-009–012]
    D[Core Gameplay: TP-013–017]
    E[AI & Spawning: TP-018–021]
    F[Game Flow & Modes: TP-022–025]
    G[UI, Arena & Assets: TP-026–030]
    H[Integration & Testing: TP-031–035]
    I[Polish & Optimization: TP-036–039]
    J[Final Build & Delivery: TP-040–043]

    A --> B
    A --> C
    B --> D
    C --> D
    C --> E
    D --> E
    D --> F
    E --> H
    F --> G
    G --> H
    H --> I
    H --> J
    I --> J
```

### Dependensi yang perlu diperhatikan

-   TP-013 membutuhkan Player, Fish, dan aturan ukuran yang sudah
    tersedia.
-   TP-015 dan TP-016 membutuhkan proses makan yang sudah berjalan.
-   TP-018 sampai TP-020 membutuhkan gerak dasar dan aturan interaksi.
-   TP-023 dan TP-024 membutuhkan Game Manager serta sistem
    pertumbuhan/skor/kematian.
-   TP-026 sampai TP-028 membutuhkan data gameplay dan status game yang
    dapat dibaca UI.
-   TP-031 baru dilakukan setelah sistem utama tersedia.
-   TP-040 sampai TP-043 dilakukan setelah build internal stabil.

------------------------------------------------------------------------

## 6. Milestone dan Definition of Done

### Milestone akhir Minggu 1 --- Fondasi proyek

-   [ ] Proyek dan struktur folder siap.
-   [ ] GitHub dapat digunakan seluruh anggota.
-   [ ] Player dan prefab ikan dasar mulai tersedia.
-   [ ] Player dapat bergerak dengan WASD.

### Milestone akhir Minggu 2 --- Player dan entitas

-   [ ] Player movement dan batas arena berfungsi.
-   [ ] Prefab Small Fish, Medium Fish, dan Predator tersedia.
-   [ ] Data ukuran gameplay sudah diterapkan.
-   [ ] Gerak dasar ikan berfungsi.

### Milestone akhir Minggu 3 --- Core gameplay

-   [ ] Aturan makan berfungsi.
-   [ ] Pertumbuhan dan skor berfungsi.
-   [ ] Kondisi Player dimangsa berfungsi.
-   [ ] AI dasar dan spawning berfungsi.

### Milestone akhir Minggu 4 --- Game dapat dimainkan

-   [ ] Game Manager berfungsi.
-   [ ] Objective Mode dan Endless Mode tersedia.
-   [ ] Main Menu dan HUD tersedia.
-   [ ] Arena utama selesai.
-   [ ] Alur permainan dapat dimainkan dari awal sampai akhir.

### Milestone akhir Minggu 5 --- Stabilitas

-   [ ] Pengujian core gameplay selesai.
-   [ ] Pengujian AI dan spawning selesai.
-   [ ] Pengujian UI dan kedua mode selesai.
-   [ ] Bug blocker diperbaiki.
-   [ ] Balancing dan polish penting selesai.

### Milestone akhir Minggu 6 --- Pengumpulan

-   [ ] Windows build berhasil dibuat.
-   [ ] Build diuji di luar Unity Editor.
-   [ ] README dan sumber aset terdokumentasi.
-   [ ] Materi demonstrasi siap.
-   [ ] Final review selesai.

### Definition of Done untuk setiap task

Sebuah task dapat dinyatakan `Done` jika: 1. Implementasi sesuai tujuan
task. 2. Acceptance criteria terpenuhi. 3. Pengujian manual yang relevan
sudah dilakukan. 4. Tidak ada error baru yang belum ditangani. 5.
Perubahan sudah ditinjau dan diintegrasikan ke branch utama sesuai
workflow tim. 6. Referensi Inspector, Prefab, Scene, dan aset yang
diperlukan tidak hilang. 7. Dokumentasi diperbarui jika perubahan
memengaruhi cara penggunaan atau struktur proyek.

------------------------------------------------------------------------

## 7. Scope Control --- Jika Waktu Tidak Mencukupi

Urutan prioritas pengurangan scope:

1.  **Pertahankan semua fitur P0:** kontrol Player, arena, ikan, aturan
    makan, pertumbuhan, skor, kondisi kalah, dua mode, UI minimum, dan
    Windows build.
2.  Sederhanakan animasi dan efek visual.
3.  Kurangi variasi dekorasi dan aset tambahan.
4.  Sederhanakan perilaku AI tanpa menghilangkan fungsi inti setiap
    kategori.
5.  Tunda audio tambahan.
6.  Tunda Boids dan fitur P3.
7.  Jangan mengorbankan pengujian build final demi fitur tambahan.

Jika jadwal mulai terlambat, tim harus mengurangi scope P2/P3 lebih
dahulu, bukan menghapus pengujian atau menunda integrasi hingga minggu
terakhir.

------------------------------------------------------------------------

## 8. Catatan Teknis Penting

1.  **Ukuran gameplay bukan skala sprite.** Gunakan atribut seperti
    `sizeLevel` untuk menentukan siapa dapat memakan siapa.
2.  **Objective Mode menang berdasarkan pertumbuhan.** Skor tidak boleh
    menjadi syarat kemenangan mode ini.
3.  **Endless Mode berakhir saat Player mati.** Pertumbuhan tidak memicu
    Victory pada mode ini.
4.  **Input menggunakan Input Manager (Old).** Jangan mencampur API
    Input System baru tanpa keputusan perubahan arsitektur.
5.  **Batas arena menggunakan dinding/collider.** Pastikan Player dan
    ikan tidak dapat keluar arena.
6.  **AI harus proporsional dengan waktu.** Perilaku wander, flee, dan
    chase sederhana lebih diprioritaskan daripada algoritma kompleks.
7.  **Aset eksternal harus memiliki sumber dan lisensi yang jelas.**
8.  **Jaga agar Scene dan Prefab tidak diedit bersamaan oleh beberapa
    anggota tanpa koordinasi.**
9.  **Jangan menganggap MCP telah menguji seluruh fitur hanya karena
    koneksi berhasil.** Pengujian gameplay tetap dilakukan melalui Unity
    Editor dan build.
10. **AI mengikuti Confirmation Before Changes.** Minta persetujuan
    sebelum tindakan yang mengubah proyek atau repository.

------------------------------------------------------------------------

## 9. Log Perubahan Dokumen

  -----------------------------------------------------------------------
  Versi                   Perubahan               Keterangan
  ----------------------- ----------------------- -----------------------
  1.0                     Penyusunan baseline     Struktur task awal
                          TASKS.md                untuk target
                                                  pengembangan enam
                                                  minggu

  -----------------------------------------------------------------------

**Akhir dokumen.**
