# C4 Cùng PTN-Gaming

## Mục Lục
- [Mốc thời gian phát triển Project](#moc-thoi-gian-phat-trien-project)
  - [16/1/2025: E9 - E20](#1612025-e9---e20)
  - [17/1/2025: E21 - E29](#1712025-e21---e29)
  - [18/1/2025: E30 - E42](#1812025-e30---e42)
  - [19/1/2025: E43 - E51](#1912025-e43---e51)
  - [20/1/2025: E52 - E59](#2012025-e52---e59)
  - [21/1/2025: Kiểm tra & tối ưu](#2112025-kiem-tra--toi-uu)
  - [23/1/2025: E60 - E62](#2312025-e60---e62)
  - [24/1/2025: E63 - E66](#2412025-e63---e66)
  - [25/1/2025: E67 - E73](#2512025-e67---e73)
  - [26/1/2025: E74 - E80](#2612025-e74---e80)
  - [27/1/2025: E81 - E85](#2712025-e81---e85)
  - [31/1/2025: E86 - E95](#3112025-e86---e95)

- [Kế hoạch sau khi hoàn thành Seri C4](#ke-hoach-sau-khi-hoan-thanh-seri-c4)
  - [Tập 20 - 30: Thiết kế thêm Map, Path, Enemy](#tap-20---30-thiet-ke-them-map-path-enemy)
  - [Tập 31 - 40: Tối ưu hóa Code](#tap-31---40-toi-uu-hoa-code)
  - [Tập 41 - 50: Generic hóa Code](#tap-41---50-generic-hoa-code)
  - [Tập 51 - 60: Thêm nhân vật mới (MultiPlay)](#tap-51---60-them-nhan-vat-moi-multiplay)
  - [Tập 61 - 70: Hệ thống Weapons, Items](#tap-61---70-he-thong-weapons-items)
  - [Tập 71 - 80: UI & Gameplay mượt mà](#tap-71---80-ui--gameplay-muot-ma)
  - [Tập 91 - 95: Âm thanh & Hiệu ứng](#tap-91---95-am-thanh--hieu-ung)

- [Kết luận 🎯](#ket-luan-🎯)

## Mốc thời gian phát triển Project

### 16/1/2025: E9 - E20
- 🚀 **Tạo GitHub**, làm quen với môi trường 3D, hoàn thành cơ bản.
- 🏗️ Hoàn thành xây dựng map (**NavMeshSurface**), hệ thống di chuyển AI (**NavAgent** cơ bản).

### 17/1/2025: E21 - E29
- 🎭 **Thêm mới nhân vật và animation di chuyển** (Mixamo.com).
- 🏗️ **Thiết lập thành công hệ thống Generic Singleton**.
- 🛤️ **Xây dựng hệ thống di chuyển theo Path** (**PathManager Singleton**).
- 🔍 **Cải tiến hàm `GetPath`**: Thêm enum để quản lý nhiều đường đi.

### 18/1/2025: E30 - E42
- 🏹 **Tower**: Thêm mục tiêu vào danh sách, tìm mục tiêu gần nhất.
- 🛠️ **Spawner & Despawn cơ bản**.
- 🔫 **Shooting cho Tower hoàn tất**.

### 19/1/2025: E43 - E51
- ⚔️ **Cơ chế truyền nhận Damage giữa Enemy và Bullet**.
- 🎭 **Xử lý Animation Enemy khi chết, bị bắn, và hồi sinh**.
- 🏹 **Enemy, Bullet... bị hủy được đưa về Object Pooling**.

### 20/1/2025: E52 - E59
- 🔦 **Tower không LookAt Enemy bị che bởi tường (Raycast)**.
- 🎭 **Thêm Model ThirdPerson vào scene và điều khiển animation**.
- 🤖 **Học Animation Rigging để điều khiển bộ phận cơ thể**.

### 21/1/2025: Kiểm tra & tối ưu
- ✅ **Xem lại code để tối ưu hiệu suất**.
- 🔄 **Chuyển FixedUpdate không cần thiết sang Coroutine**.
- ⚡ **Tối ưu Spawner, Moving của Bullet/Enemy**.
- 🏹 **Chuyển từ GetName sang Enum để dễ quản lý**.

### 23/1/2025: E60 - E62
- 🎭 **Hoàn thiện Attack Animation**.
- 🛠️ **Fix Animation Rigging: mixamorig:Spine2 là điểm chính xác**.
- 🔄 **Test lại Coroutine vs Update: Hiệu suất tăng nhưng giảm độ mượt**.

### 24/1/2025: E63 - E66
- 🎯 **Hoàn thiện Shooting & Effects**.
- 🏹 **Thiết lập Inventory (Currencies, Items).**
- 🎭 **Làm quen với Scriptable Object**.

### 25/1/2025: E67 - E73
- 🏆 **Nhận vàng khi giết quái**.
- 🏪 **Thiết kế UI Inventory**.
- 🔄 **Cập nhật Items & Currencies lên UI**.

### 26/1/2025: E74 - E80
- 🎒 **Hệ thống Inventory hoàn chỉnh**.
- 🎁 **ItemDropManager** (quái rơi vật phẩm).
- ⌨️ **InputHotkey để bật/tắt Inventory**.

### 27/1/2025: E81 - E85
- 📈 **Hệ thống Level cho Player, Tower...**
- 🎭 **Hiển thị Exp, Level trên UI**.
- 🩸 **Thanh máu cho Enemy**.
- 🔥 **Hiệu ứng Shooting của Tower**.

### 31/1/2025: E86 - E95
- 🎵 **Hệ thống hiệu ứng âm thanh và nhạc nền.**
- 💥 **Hiệu ứng va chạm, Tower Muzzle...**

## 📌 Kế hoạch sau khi hoàn thành Seri C4

### 🏗️ Tập 20 - 30: Thiết kế thêm Map, Path, Enemy
- 🗺️ **Thêm 4 Map với độ khó khác nhau**.
- 👾 **Thiết kế thêm 8 Enemy với khả năng riêng**.

### ⚡ Tập 31 - 40: Tối ưu hóa Code
- ⚙️ **Tối ưu hóa TowerShooting, Targeting, Spawning...**

### 🔧 Tập 41 - 50: Generic hóa Code
- 🏹 **Tạo các Generic Class để tối ưu quản lý code**.


## 🎯 Kết luận

- 🏆 **Sau 12 ngày**, đã hoàn thành **Seri C4**, nắm chắc các kiến thức cần thiết.
- 🎯 Mục tiêu tiếp theo: **Xây dựng game hoàn chỉnh theo kế hoạch đề ra** 🚀. Dự kiến **hoàn thành trong 1 tháng**.
- 🙏 **Cảm ơn mọi người đã theo dõi và giúp đỡ!** 💙

