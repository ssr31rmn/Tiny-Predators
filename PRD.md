# PRODUCT REQUIREMENTS DOCUMENT (PRD)

## Tiny Predators

  Informasi                   Detail
  --------------------------- -------------------------------------
  Nama proyek                 Tiny Predators
  Jenis dokumen               Product Requirements Document (PRD)
  Versi dokumen               1.0
  Status                      Draft kebutuhan produk
  Platform target             PC / Windows
  Genre                       2D Arcade Survival
  Mode permainan              Single-player
  Engine                      Unity 6.6
  Bahasa pemrograman          C#
  Tim pengembang              3 orang
  Target waktu pengembangan   6 minggu

------------------------------------------------------------------------

## 1. Pendahuluan

### 1.1 Tujuan Dokumen

Dokumen Product Requirements Document (PRD) ini menjelaskan kebutuhan
produk dan fitur yang harus dipenuhi dalam pengembangan game **Tiny
Predators**. Dokumen ini menjadi acuan tim dalam menentukan ruang
lingkup, merancang mekanisme permainan, mengimplementasikan fitur, serta
memvalidasi hasil pengembangan.

PRD berfokus pada kebutuhan dan perilaku game dari sudut pandang pemain.
Pembagian tugas, alur kerja GitHub, standar kolaborasi, dan jadwal
teknis pengembangan dijelaskan lebih lanjut dalam dokumen `WORKFLOW.md`.

### 1.2 Gambaran Produk

Tiny Predators adalah game 2D Arcade Survival bertema kehidupan bawah
laut. Pemain mengendalikan seekor ikan kecil yang harus memakan ikan
berukuran lebih kecil untuk memperoleh skor dan meningkatkan ukuran
tubuh. Pemain harus menghindari ikan yang lebih besar karena ikan
tersebut dapat memangsa pemain.

Game menyediakan dua mode, yaitu **Objective Mode** dengan target
pencapaian tertentu dan **Endless Mode** untuk bertahan hidup serta
memperoleh skor setinggi mungkin. Game dirancang untuk dimainkan secara
single-player pada PC Windows dengan visual Cartoon 2D.

### 1.3 Tujuan Produk

Tujuan utama Tiny Predators adalah: - Menghadirkan permainan survival
sederhana yang mudah dipahami dan dimainkan. - Menerapkan mekanisme
rantai makanan melalui aturan memangsa berdasarkan ukuran ikan. -
Memberikan perkembangan karakter melalui sistem skor dan pertumbuhan. -
Menyediakan dua variasi pengalaman bermain melalui Objective Mode dan
Endless Mode. - Menghasilkan game 2D yang berfungsi secara utuh dan
dapat dimainkan pada Windows.

------------------------------------------------------------------------

## 2. Target Pengguna dan Pengalaman Bermain

### 2.1 Target Pengguna

Target pengguna utama adalah pemain kasual yang menyukai game arcade
sederhana, khususnya permainan dengan mekanisme bertahan hidup,
mengumpulkan skor, dan mengembangkan karakter.

Game tidak mensyaratkan pengalaman bermain yang tinggi. Aturan dasar
harus dapat dipahami melalui tampilan antarmuka dan pengalaman bermain
langsung.

### 2.2 Pengalaman yang Diharapkan

Pemain diharapkan dapat: 1. Memahami tujuan permainan dari Main Menu. 2.
Memilih Objective Mode atau Endless Mode. 3. Mengendalikan ikan
menggunakan tombol WASD. 4. Mengenali ikan yang dapat dimangsa dan ikan
yang menjadi ancaman. 5. Memperoleh skor dan mengalami pertumbuhan
setelah berhasil memangsa ikan yang lebih kecil. 6. Menghindari predator
dan memahami kondisi menang atau kalah. 7. Mengulang permainan atau
kembali ke Main Menu setelah permainan berakhir.

------------------------------------------------------------------------

## 3. Ruang Lingkup Produk

### 3.1 Fitur dalam Ruang Lingkup (In Scope)

Versi awal Tiny Predators wajib mencakup: - Main Menu. - Pemilihan
Objective Mode dan Endless Mode. - Arena permainan bawah laut 2D. -
Kontrol gerakan pemain menggunakan WASD. - Karakter ikan pemain. - Ikan
kecil, ikan sedang, dan predator. - Pergerakan dasar ikan yang
dikendalikan AI. - Aturan memangsa berdasarkan perbandingan ukuran. -
Sistem pertumbuhan pemain. - Sistem skor. - Kondisi kematian pemain. -
Kondisi kemenangan Objective Mode. - HUD untuk menampilkan informasi
permainan. - Pause dan Resume. - Game Over, Victory, Restart, dan
kembali ke Main Menu. - Build game yang dapat dijalankan pada Windows.

### 3.2 Fitur di Luar Ruang Lingkup (Out of Scope)

Fitur berikut tidak menjadi prioritas versi awal dan hanya dapat
dipertimbangkan apabila seluruh kebutuhan utama telah stabil: -
Multiplayer atau permainan online. - Sistem akun dan penyimpanan
cloud. - Banyak level atau arena dengan progres antartingkat. - Sistem
inventaris, equipment, atau skill. - Pohon evolusi dan variasi kemampuan
kompleks. - AI berbasis machine learning. - Pathfinding atau simulasi
perilaku kawanan yang kompleks. - Sistem leaderboard online. -
Monetisasi, iklan, atau in-app purchase.

------------------------------------------------------------------------

## 4. Alur Utama Permainan

Alur umum permainan:

1.  Game dijalankan dan menampilkan Main Menu.
2.  Pemain memilih Objective Mode atau Endless Mode.
3.  Game memuat arena permainan.
4.  Pemain menggerakkan ikan menggunakan WASD.
5.  Pemain mencari dan memangsa ikan yang lebih kecil.
6.  Setiap keberhasilan memangsa ikan memberikan skor dan meningkatkan
    ukuran pemain sesuai aturan pertumbuhan.
7.  Ikan yang lebih besar dapat memangsa pemain. Jika pemain dimangsa,
    karakter pemain mati dan permainan berakhir.
8.  Pada Objective Mode, pemain menang apabila target yang ditentukan
    berhasil dicapai sebelum pemain mati.
9.  Pada Endless Mode, permainan berlanjut sampai pemain mati.
10. Setelah permainan berakhir, game menampilkan layar Victory atau Game
    Over sesuai hasil permainan. Pemain dapat mengulang permainan atau
    kembali ke Main Menu.

------------------------------------------------------------------------

## 5. Kebutuhan Fungsional

Prioritas: - **Must**: wajib tersedia pada versi akhir. - **Should**:
penting, tetapi dapat disederhanakan jika waktu terbatas. - **Could**:
tambahan jika waktu memungkinkan.

### FR-01 --- Main Menu

**Prioritas:** Must

Game harus menampilkan Main Menu sebelum permainan dimulai.

Kriteria penerimaan: - Pemain dapat melihat judul game. - Tersedia
pilihan untuk memulai Objective Mode. - Tersedia pilihan untuk memulai
Endless Mode. - Tersedia pilihan keluar dari game. - Setiap pilihan
memberikan respons yang sesuai.

### FR-02 --- Pemilihan Mode

**Prioritas:** Must

Pemain harus dapat memilih salah satu dari dua mode permainan.

Kriteria penerimaan: - Objective Mode memulai permainan dengan target
pencapaian. - Endless Mode memulai permainan tanpa target kemenangan. -
Mode yang dipilih diterapkan pada sesi permainan yang sedang berjalan. -
Kedua mode menggunakan mekanisme inti permainan yang sama.

### FR-03 --- Gerakan Pemain

**Prioritas:** Must

Pemain harus dapat mengendalikan ikan menggunakan tombol WASD.

Kriteria penerimaan: - W menggerakkan pemain ke atas. - A menggerakkan
pemain ke kiri. - S menggerakkan pemain ke bawah. - D menggerakkan
pemain ke kanan. - Gerakan tetap konsisten pada variasi frame rate. -
Pemain tidak dapat bergerak ketika permainan sedang Pause atau telah
berakhir.

### FR-04 --- Karakter dan Jenis Ikan

**Prioritas:** Must

Game harus memiliki setidaknya empat kategori entitas ikan: - Player:
karakter yang dikendalikan pemain. - Small Fish: ikan kecil yang dapat
menjadi mangsa awal pemain. - Medium Fish: ikan berukuran menengah yang
memiliki interaksi dengan ikan lebih kecil. - Predator: ikan besar yang
menjadi ancaman bagi pemain.

Kriteria penerimaan: - Setiap kategori memiliki identitas visual yang
dapat dibedakan. - Setiap ikan memiliki nilai ukuran gameplay yang
digunakan dalam aturan interaksi. - Ukuran gameplay tidak hanya
ditentukan berdasarkan besar-kecil tampilan sprite.

### FR-05 --- Sistem Memangsa

**Prioritas:** Must

Pemain hanya dapat memangsa ikan yang ukuran gameplay-nya lebih kecil
daripada ukuran pemain.

Kriteria penerimaan: - Ketika pemain menyentuh ikan yang lebih kecil,
ikan tersebut dimangsa dan dihilangkan dari arena. - Pemain memperoleh
skor dan pertumbuhan sesuai konfigurasi permainan. - Pemain tidak dapat
memangsa ikan yang ukuran gameplay-nya sama atau lebih besar. - Ketika
pemain bersentuhan dengan ikan yang lebih besar dan ikan tersebut
merupakan pemangsa, pemain mati. - Satu kejadian tabrakan tidak boleh
memberikan skor atau pertumbuhan berulang kali.

### FR-06 --- Sistem Pertumbuhan

**Prioritas:** Must

Pemain harus mengalami pertumbuhan setelah berhasil memangsa ikan yang
memenuhi syarat.

Kriteria penerimaan: - Ukuran pemain meningkat berdasarkan aturan
pertumbuhan yang ditetapkan. - Perubahan ukuran visual mengikuti ukuran
gameplay pemain. - Pertumbuhan memengaruhi kemampuan pemain dalam
memangsa ikan berikutnya. - Pertumbuhan tidak terjadi jika pemain
menyentuh ikan yang tidak dapat dimangsa.

Catatan: nilai pertumbuhan, batas ukuran, dan hubungan antara skor
dengan ukuran perlu ditentukan melalui balancing dan pengujian.

### FR-07 --- Sistem Skor

**Prioritas:** Must

Game harus mencatat skor yang diperoleh pemain selama satu sesi
permainan.

Kriteria penerimaan: - Skor bertambah ketika pemain berhasil memangsa
ikan. - Besarnya skor mengikuti nilai yang ditentukan untuk jenis ikan
terkait. - Skor ditampilkan pada HUD selama permainan. - Skor akhir
ditampilkan pada layar hasil permainan. - Skor diinisialisasi kembali
ketika sesi permainan baru dimulai.

### FR-08 --- Perilaku AI Ikan

**Prioritas:** Must

Ikan yang tidak dikendalikan pemain harus memiliki perilaku gerak
otomatis.

Kebutuhan perilaku minimum: - Small Fish bergerak menjelajahi area
secara sederhana dan dapat menghindari ancaman jika waktu
memungkinkan. - Medium Fish dapat bergerak menjelajahi area dan mengejar
ikan yang lebih kecil. - Predator bergerak menjelajahi atau berpatroli
dan mengejar pemain ketika pemain berada dalam jangkauan deteksi.

Kriteria penerimaan: - Ikan bergerak tanpa input pemain. - Perilaku AI
tidak menyebabkan ikan keluar arena secara permanen. - Predator dapat
mendekati dan memangsa pemain sesuai aturan ukuran. - AI tetap berjalan
secara wajar setelah permainan dimulai kembali.

Catatan: implementasi AI dapat menggunakan Finite State Machine (FSM)
sederhana. Perilaku tambahan seperti Boids bukan kebutuhan wajib.

### FR-09 --- Spawn Ikan

**Prioritas:** Should

Game sebaiknya dapat menghadirkan ikan ke arena agar permainan tidak
cepat kosong.

Kriteria penerimaan: - Ikan dapat muncul pada posisi yang masih berada
di dalam arena. - Jumlah ikan dijaga dalam batas yang wajar. - Spawn
tidak menempatkan ikan secara langsung di luar area permainan. - Sistem
spawn tidak membuat jumlah objek bertambah tanpa kendali.

Jika sistem spawn dinamis terlalu berisiko terhadap jadwal, jumlah ikan
dapat disediakan sejak awal sesi sebagai penyederhanaan.

### FR-10 --- Objective Mode

**Prioritas:** Must

Objective Mode harus memiliki target yang harus dicapai pemain untuk
memenangkan permainan.

Kriteria penerimaan: - Target permainan ditampilkan atau dijelaskan
kepada pemain. - Target dapat berupa skor atau tingkat pertumbuhan yang
ditentukan. - Pemain memperoleh kondisi Victory ketika target
tercapai. - Jika pemain mati sebelum target tercapai, game menampilkan
Game Over. - Setelah Victory, permainan berhenti menerima input
gameplay.

Catatan: jenis target final dan nilai target harus diputuskan sebelum
balancing akhir. Untuk versi awal, gunakan satu jenis target yang paling
mudah diukur dan diuji.

### FR-11 --- Endless Mode

**Prioritas:** Must

Endless Mode harus memungkinkan pemain bertahan dan mengumpulkan skor
tanpa target kemenangan.

Kriteria penerimaan: - Tidak ada target skor atau pertumbuhan yang
mengakhiri permainan dengan kondisi Victory. - Skor terus bertambah
selama pemain berhasil memangsa ikan. - Permainan berakhir ketika pemain
mati. - Skor akhir ditampilkan pada layar Game Over.

### FR-12 --- HUD

**Prioritas:** Must

Game harus menampilkan informasi penting selama permainan berlangsung.

Informasi minimum: - Skor pemain. - Indikator ukuran atau pertumbuhan
pemain. - Informasi target Objective Mode ketika mode tersebut aktif. -
Tombol atau petunjuk Pause.

Kriteria penerimaan: - Informasi diperbarui ketika skor atau ukuran
berubah. - Informasi tidak tertutup oleh elemen arena yang mengganggu
keterbacaan. - HUD menyesuaikan mode permainan yang sedang aktif.

### FR-13 --- Pause dan Resume

**Prioritas:** Must

Pemain harus dapat menghentikan sementara dan melanjutkan permainan.

Kriteria penerimaan: - Pemain dapat mengaktifkan Pause ketika permainan
berlangsung. - Saat Pause, gerakan pemain dan AI serta proses gameplay
berhenti. - Pemain dapat memilih Resume untuk melanjutkan permainan. -
Pemain dapat kembali ke Main Menu melalui pilihan yang disediakan. -
Pause tidak dapat mengubah hasil permainan yang sudah berakhir.

### FR-14 --- Victory dan Game Over

**Prioritas:** Must

Game harus menampilkan hasil sesi permainan dengan jelas.

Kriteria penerimaan: - Victory hanya ditampilkan ketika target Objective
Mode tercapai. - Game Over ditampilkan ketika pemain mati sebelum
mencapai target atau ketika pemain mati dalam Endless Mode. - Layar
hasil menampilkan skor akhir. - Pemain dapat memilih Restart. - Pemain
dapat kembali ke Main Menu. - Memulai ulang permainan menginisialisasi
ulang skor, ukuran pemain, ikan, dan status mode.

### FR-15 --- Keluar dari Game

**Prioritas:** Must

Pemain harus dapat keluar dari aplikasi melalui Main Menu. Perintah
keluar harus bekerja pada build Windows.

------------------------------------------------------------------------

## 6. Aturan dan Logika Gameplay

### 6.1 Aturan Ukuran

Setiap ikan harus memiliki atribut ukuran gameplay yang eksplisit,
misalnya `sizeLevel` atau `sizeValue`. Nilai ini menjadi dasar penentuan
apakah suatu ikan dapat memangsa ikan lain.

Aturan dasar: - Jika ukuran pemangsa lebih besar daripada ukuran target,
pemangsa dapat memakan target. - Jika ukuran keduanya sama, tidak
terjadi proses memangsa. - Jika ukuran pemangsa lebih kecil daripada
target, pemangsa tidak dapat memakannya. - Predator yang lebih besar
dapat memangsa pemain. - Pemain yang telah tumbuh dapat memangsa jenis
ikan yang sebelumnya terlalu besar, selama nilai ukurannya sudah
memenuhi syarat.

### 6.2 Aturan Skor dan Pertumbuhan

-   Memangsa ikan yang valid memberikan skor.
-   Memangsa ikan yang valid meningkatkan ukuran pemain.
-   Nilai skor dan pertumbuhan dapat berbeda berdasarkan jenis ikan.
-   Nilai numerik final ditetapkan melalui pengujian keseimbangan
    permainan.

### 6.3 Kondisi Akhir Permainan

  Mode        Kondisi                               Hasil
  ----------- ------------------------------------- ---------------------
  Objective   Target tercapai sebelum pemain mati   Victory
  Objective   Pemain mati sebelum target tercapai   Game Over
  Endless     Pemain masih hidup                    Permainan berlanjut
  Endless     Pemain mati                           Game Over

### 6.4 Status Permainan

Secara konseptual, game setidaknya memiliki status: - Main Menu -
Playing - Paused - Victory - Game Over

Perubahan status harus dikelola secara konsisten agar input, AI, skor,
dan UI tidak berjalan pada kondisi yang salah.

------------------------------------------------------------------------

## 7. Kebutuhan Antarmuka dan Visual

### 7.1 Gaya Visual

-   Gaya visual utama: Cartoon 2D.
-   Tema lingkungan: bawah laut.
-   Karakter ikan harus mudah dibedakan berdasarkan jenis dan ukuran.
-   Tampilan mengutamakan keterbacaan objek yang menjadi mangsa dan
    ancaman.

### 7.2 Layar yang Dibutuhkan

  -----------------------------------------------------------------------
  Layar / Elemen                      Fungsi
  ----------------------------------- -----------------------------------
  Main Menu                           Menampilkan judul dan pilihan mode

  Arena Game                          Area utama tempat permainan
                                      berlangsung

  HUD                                 Menampilkan skor, pertumbuhan, dan
                                      target

  Pause Menu                          Menghentikan sementara dan
                                      menyediakan Resume / Main Menu

  Victory Screen                      Menampilkan keberhasilan Objective
                                      Mode

  Game Over Screen                    Menampilkan kegagalan atau akhir
                                      Endless Mode

  Restart                             Memulai sesi baru
  -----------------------------------------------------------------------

### 7.3 Lingkungan Arena

Versi awal menggunakan satu arena bawah laut. Elemen visual dapat
meliputi gradasi warna biru, karang, tumbuhan laut, batu, dan gelembung.
Elemen dekoratif tidak boleh menghalangi keterbacaan ikan atau
mengganggu kontrol pemain.

------------------------------------------------------------------------

## 8. Kebutuhan Non-Fungsional

### NFR-01 --- Platform

Game harus dapat dijalankan pada PC dengan sistem operasi Windows
melalui build yang dihasilkan Unity.

### NFR-02 --- Performa

Game harus berjalan dengan lancar pada perangkat pengembangan dan
perangkat pengujian tim yang memenuhi spesifikasi minimum proyek. Tim
harus melakukan pengujian pada build, bukan hanya melalui Unity Editor.

### NFR-03 --- Respons Kontrol

Input WASD harus terasa responsif dan tidak mengalami jeda yang
mengganggu permainan.

### NFR-04 --- Stabilitas

Game tidak boleh mengalami crash atau error yang menghalangi pemain
menyelesaikan satu sesi permainan normal.

### NFR-05 --- Keterbacaan

Teks UI, skor, target, dan informasi hasil permainan harus dapat dibaca
dengan jelas.

### NFR-06 --- Kemudahan Penggunaan

Pemain harus dapat memulai permainan, memahami kontrol dasar, melakukan
Pause, dan mengulang permainan tanpa prosedur yang rumit.

### NFR-07 --- Konsistensi

Perilaku permainan, aturan ukuran, skor, dan kondisi menang/kalah harus
konsisten pada kedua mode.

------------------------------------------------------------------------

## 9. Kriteria Penerimaan Produk (Product Acceptance Criteria)

Produk dinyatakan memenuhi kebutuhan versi awal apabila seluruh kriteria
Must berikut berhasil diuji:

-   [ ] Build Windows dapat dijalankan.
-   [ ] Main Menu tampil dan pilihan mode berfungsi.
-   [ ] Objective Mode dapat dimulai dan memiliki target.
-   [ ] Endless Mode dapat dimulai tanpa target kemenangan.
-   [ ] Pemain dapat bergerak menggunakan WASD.
-   [ ] Ikan non-pemain bergerak menggunakan AI.
-   [ ] Pemain dapat memangsa ikan yang lebih kecil.
-   [ ] Pemain tidak dapat memangsa ikan yang sama besar atau lebih
    besar.
-   [ ] Pemain memperoleh skor dan pertumbuhan setelah memangsa ikan
    yang valid.
-   [ ] Predator yang lebih besar dapat memangsa pemain.
-   [ ] Kematian pemain mengakhiri sesi permainan.
-   [ ] Objective Mode menampilkan Victory ketika target tercapai.
-   [ ] Objective Mode menampilkan Game Over jika pemain mati sebelum
    target tercapai.
-   [ ] Endless Mode berakhir dengan Game Over ketika pemain mati.
-   [ ] HUD menampilkan skor dan indikator pertumbuhan.
-   [ ] Pause menghentikan gameplay dan Resume melanjutkannya.
-   [ ] Restart memulai sesi baru dengan status yang bersih.
-   [ ] Pemain dapat kembali ke Main Menu.
-   [ ] Tidak ada bug kritis yang menghalangi alur permainan utama.

------------------------------------------------------------------------

## 10. Risiko Produk dan Mitigasi

  -----------------------------------------------------------------------
  Risiko                  Dampak                  Mitigasi
  ----------------------- ----------------------- -----------------------
  Fitur terlalu banyak    Fitur utama tidak       Prioritaskan seluruh
  untuk enam minggu       selesai                 kebutuhan Must sebelum
                                                  fitur tambahan

  AI ikan terlalu         Waktu implementasi dan  Gunakan FSM dan
  kompleks                debugging meningkat     steering sederhana

  Aturan ukuran tidak     Pemain dapat memangsa   Gunakan atribut ukuran
  konsisten               atau dimangsa secara    gameplay terpisah dari
                          keliru                  skala visual

  Konflik saat            Proyek sulit            Tetapkan penanggung
  menggabungkan Scene     diintegrasikan          jawab Scene/Prefab dan
  atau Prefab                                     hindari edit bersamaan

  Bug muncul menjelang    Build tidak stabil      Lakukan integrasi dan
  deadline                                        pengujian sejak minggu
                                                  pertama

  Nilai skor dan          Permainan terlalu mudah Lakukan playtesting dan
  pertumbuhan tidak       atau sulit              balancing bertahap
  seimbang                                        

  Aset eksternal tidak    Tampilan tidak          Gunakan aset yang
  sesuai kebutuhan        konsisten atau lisensi  sesuai dan periksa
                          bermasalah              ketentuan lisensinya
  -----------------------------------------------------------------------

------------------------------------------------------------------------

## 11. Asumsi dan Keputusan yang Masih Perlu Ditetapkan

Beberapa detail belum ditentukan secara numerik atau final. Tim perlu
menetapkannya sebelum tahap balancing dan finalisasi:

1.  **Target Objective Mode:** apakah target berupa skor atau
    ukuran/level pertumbuhan. Disarankan memilih satu target utama untuk
    versi awal.
2.  **Nilai skor:** berapa skor yang diberikan setiap jenis ikan.
3.  **Nilai pertumbuhan:** seberapa besar ukuran pemain bertambah
    setelah memangsa setiap jenis ikan.
4.  **Batas ukuran:** berapa tingkatan ukuran pemain dan ikan.
5.  **Kecepatan:** kecepatan pemain, ikan kecil, ikan sedang, dan
    predator.
6.  **Jangkauan deteksi predator:** jarak ketika predator mulai mengejar
    pemain.
7.  **Spawn:** jumlah awal ikan, batas maksimum, dan aturan kemunculan
    ikan baru.
8.  **Batas arena:** apakah pemain dan ikan dibatasi oleh dinding arena
    atau menggunakan mekanisme keluar-masuk dari sisi layar.
9.  **Resolusi dan rasio layar:** resolusi target build dan dukungan
    perubahan ukuran jendela.
10. **Audio:** jenis musik dan efek suara yang akan dimasukkan jika
    waktu memungkinkan.

Keputusan tersebut tidak boleh diisi dengan angka perkiraan tanpa
pengujian. Tim dapat memulai dengan nilai sementara, lalu mencatat dan
menyesuaikannya melalui playtesting.

------------------------------------------------------------------------

## 12. Hubungan dengan Dokumen Proyek Lain

Dokumen ini digunakan bersama dokumen proyek berikut: - `WORKFLOW.md`
--- mengatur pembagian tanggung jawab, standar pengembangan, GitHub
workflow, jadwal enam minggu, dan Definition of Done tim. -
`AI-CONTEXT.md` atau `AGENTS.md` --- menjelaskan konteks proyek dan
aturan bagi AI coding assistant. - README proyek --- menjelaskan
identitas proyek, kebutuhan perangkat, dan cara menjalankan game.

Jika terjadi perubahan kebutuhan fitur, tim harus memperbarui PRD dan
memastikan perubahan tersebut tidak bertentangan dengan jadwal serta
ruang lingkup yang telah disepakati.

------------------------------------------------------------------------

## 13. Penutup

PRD ini menjadi acuan kebutuhan produk Tiny Predators untuk versi awal.
Fokus pengembangan adalah menghasilkan game 2D Arcade Survival yang
memiliki alur permainan lengkap, aturan memangsa berdasarkan ukuran yang
konsisten, sistem skor dan pertumbuhan, dua mode permainan, serta
antarmuka yang mendukung pengalaman bermain. Fitur tambahan hanya
dikembangkan setelah seluruh kebutuhan utama berhasil diimplementasikan
dan diuji.
