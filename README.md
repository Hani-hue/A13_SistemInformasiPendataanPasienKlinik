# Sistem Informasi Pendataan Pasien Klinik

#form koneksi
<img width="1920" height="1200" alt="Screenshot 2026-04-15 041552" src="https://github.com/user-attachments/assets/551be780-a2cf-4d97-b555-0e7701b5a9d7" />

#Form input data
<img width="1920" height="1200" alt="Screenshot 2026-04-15 041848" src="https://github.com/user-attachments/assets/9ce775ff-495b-4285-b503-04dd06a131f6" />
<img width="877" height="575" alt="Screenshot 2026-04-15 041924" src="https://github.com/user-attachments/assets/e4d6bf52-b287-4fe8-9cc5-f43284824871" />

#Form tampilan data
<img width="874" height="576" alt="Screenshot 2026-04-15 042421" src="https://github.com/user-attachments/assets/ba2ff7d5-7868-4297-bae5-8a181ce4c868" />

#Bukti insert, update, delete, dan search
<img width="1920" height="1200" alt="Screenshot 2026-04-15 042100" src="https://github.com/user-attachments/assets/b3a6a2e4-bffe-4b50-99e0-1f4bb37db248" />
<img width="881" height="579" alt="Screenshot 2026-04-15 042113" src="https://github.com/user-attachments/assets/ab16e3f1-8837-4d6b-9ec1-c8723e88c1f6" />
<img width="799" height="483" alt="Screenshot 2026-04-15 042153" src="https://github.com/user-attachments/assets/8abc58b6-00bc-4f61-bfa2-20974aecd845" />
<img width="952" height="579" alt="Screenshot 2026-04-15 042406" src="https://github.com/user-attachments/assets/1284a4fb-02b6-4468-9f5f-f6ab9cbf24c2" />

Skenario 1: Percobaan SQL Injection pada Integritas Data
Simulasi ini membuktikan bahwa penggunaan metode string concatenation pada fungsi update sangat rentan terhadap serangan SQL Injection, di mana manipulasi payload pada input ID dapat mengakibatkan modifikasi data pasien secara masif, sehingga menegaskan pentingnya penerapan Parameterized Query atau Stored Procedure sebagai standar keamanan database.
<img width="1920" height="1200" alt="Screenshot 2026-05-12 212418" src="https://github.com/user-attachments/assets/3b150c7b-2e9a-415f-b695-3c419bb87b30" />
Hasil akhir
<img width="1920" height="1200" alt="Screenshot 2026-05-12 212432" src="https://github.com/user-attachments/assets/a4c2a4f4-5e21-46a6-ac35-62d7a56925c2" />

Skenario 2: Mekanisme Pemulihan Data (Data Recovery) melalui Prosedur Reset
Simulasi ini menunjukkan bahwa prosedur restorasi melalui fitur Reset Data mampu mengembalikan konsistensi sistem yang terkompromi dengan menghapus data rusak dan memulihkannya dari tabel backup, sekaligus membuktikan efektivitas strategi Defense in Depth dalam meminimalisir risiko kehilangan informasi permanen.
<img width="1920" height="1200" alt="Screenshot 2026-05-12 213012" src="https://github.com/user-attachments/assets/2ca25211-37ed-4612-aea2-947d406a76e7" />
Hasil akhir
<img width="1920" height="1200" alt="Screenshot 2026-05-12 221115" src="https://github.com/user-attachments/assets/b83fe859-bf22-44be-98da-92333c17e746" />
<img width="1920" height="1200" alt="Screenshot 2026-05-12 223102" src="https://github.com/user-attachments/assets/5252bbf8-21cf-442c-ac40-5cb3b178e292" />











