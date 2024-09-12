const tblStu = "Tbl_Stu";
run();
function run() {
  // create("Tun Tun", "Aung Myint", "Tun Tun is Bio Student");
  // read();
  // const id = prompt("Enter ID");
  // const stuName = prompt("Enter Student Name");
  // const FatherName = prompt("Enter FatherName");
  // const stuContent = prompt("Enter stuContent");
  // update(id, stuName, FatherName, stuContent);
}
function read() {
  const lstStr = getItem();
  for (i = 0; i < lstStr.length; i++) {
    let item = lstStr[i];
    console.log(item.stuName);
    console.log(item.FatherName);
    console.log(item.stuContent);
  }
}
function edit(id) {
  let lstStr = getItem();
  let lst = lstStr.filter((x) => x.id === id); //array
  if (lst.length === 0) {
    console.log("No Data Found");
    return;
  }
  let item = lst[0];
  console.log(item);
}
function create(stuName, FatherName, stuContent) {
  const lstStr = getItem();
  const student = {
    id: uuidv4(),
    stuName: stuName,
    FatherName: FatherName,
    stuContent: stuContent,
  };
  lstStr.push(student);
  setlocalStorage(lstStr);
}
function update(id, stuName, FatherName, stuContent) {
  let lstStr = getItem();
  let lst = lstStr.filter((x) => x.id === id); //array
  if (lst.length === 0) {
    console.log("No Data Found");
    return;
  }
  let index = lstStr.findIndex((x) => x.id === id);
  lstStr[index] = {
    id: id,
    stuName: stuName,
    FatherName: FatherName,
    stuContent: stuContent,
  };
  setlocalStorage(lstStr);
}
function deleteitem(id) {
  let lstStr = getItem();
  let lst = lstStr.filter((x) => x.id === id);
  if (lst.length === 0) {
    console.log("No Data Found");
    return;
  }
  //let item=lst[0];
  lstStr = lstStr.filter((x) => x.id !== id);
  setlocalStorage(lstStr);
}
function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}
function getItem() {
  let lstStu = [];
  let stuStr = localStorage.getItem(tblStu);
  if (stuStr != null) {
    lstStu = JSON.parse(stuStr);
  }
  return lstStu;
}
function setlocalStorage(lstStr) {
  let jsonStr = JSON.stringify(lstStr);
  localStorage.setItem(tblStu, jsonStr);
}
