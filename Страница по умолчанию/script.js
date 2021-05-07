 var serverResponse = document.querySelector('#response')

     //Post function
    document.forms.postForm.onsubmit = function(e){
     e.preventDefault();

    //create json
     const toSend = {
     code: Number(document.getElementById("codeInp").value),
     value: document.getElementById("valueInp").value
    };
    const jsonString = JSON.stringify(toSend);

    //create POST method
     const xhr = new XMLHttpRequest();
     xhr.open("POST", "https://localhost:5001/api/valueCode");
     xhr.setRequestHeader("Content-Type", "application/json");
     xhr.setRequestHeader('Accept', 'application/json');
     xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
     xhr.send(jsonString);
 }

 //Patch function
 document.forms.patchForm.onsubmit = function(e){
     e.preventDefault();

     var id = document.getElementById("idInp").value;
     var code = Number(document.getElementById("code").value);
     var value = document.getElementById("value").value

     //create json
     if(id != "")
     {         
         //chande code + value
         if(code != "" && value != "")
         {
            const codeValueSend = [{
                op: "replace",
                path: "/code",
                value: Number(code)
            },
            {
                op: "replace",
                path: "/value",
                value: value
            }];
            const jsonString = JSON.stringify(codeValueSend);

            //create PATCH method
            Patch(id, jsonString);
         }
         //change code
         else if(code != "")
         {
            const codeSend = [{
                op: "replace",
                path: "/code",
                value: Number(code)
            }];
            const jsonString = JSON.stringify(codeSend);

            //create PATCH method
            Patch(id, jsonString);
         }
         //change value
         else if(value != "")
         {
            const valueSend = [{
                op: "replace",
                path: "/value",
                value: value
            }];
            const jsonString = JSON.stringify(valueSend);

            //create PATCH method
            Patch(id, jsonString);
         }
     }
     var c=document.cookie;
     console.log("enter id");
 }

 function Patch(id, jsonString){
    //create PATCH method
    const xhr = new XMLHttpRequest();
    var path = "https://localhost:5001/api/valueCode/"+id;
    xhr.open("PATCH", path);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.setRequestHeader('Accept', 'application/json');
    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    xhr.send(jsonString);
 }


 //Get function
 document.forms.getForm.onsubmit = function(e){
    e.preventDefault();

    //create GET method
    const xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:5001/api/valueCode', true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.setRequestHeader('Accept', 'application/json');
    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    xhr.send();

    xhr.onreadystatechange = function() {
    if (xhr.readyState != 4) {
        return
    }

    if (xhr.status === 200) {
        var res = JSON.parse(xhr.responseText);

        main(res);
        console.log('result', JSON.parse(xhr.responseText))
    }else {
        console.log('error', xhr.responseText)
    }
    }   
 }

 //Delete table function
 document.forms.deleteTable.onsubmit = function(e){
    e.preventDefault();
     var table = document.getElementById("tbl");
    for(var i = 0; i < table.rows.length;)
    {   
        table.deleteRow(i);
    }
 }

 //Create table function
 function addCell(tr, val) {
    var td = document.createElement('td');

    td.innerHTML = val;

    tr.appendChild(td)
  }

  function addRow(tbl, val_1, val_2) {
    var tr = document.createElement('tr');
    
    addCell(tr, val_1);
    addCell(tr, val_2);

    tbl.appendChild(tr)
    addRowHandlers();
  }

  function main(array) {
    tbl = document.getElementById('tbl');

    var rows=array.length;

    for(var i =0; i<rows; i++)
    {
        addRow(tbl, array[i].code, array[i].value);
    }
  }

  function addRowHandlers() {
    var table = document.getElementById("tbl");
    var rows = table.getElementsByTagName("tr");
    for (i = 0; i < rows.length; i++) {
      var currentRow = table.rows[i];
      var createClickHandler = function(row) {
        return function() {
          var cell = row.getElementsByTagName("td")[0];
          var code = cell.innerHTML;
          GetByCode(code);
        };
      };
      currentRow.onclick = createClickHandler(currentRow);
    }
  }

  //GET by code method
function GetByCode(code){

    //create GET method
    const xhr = new XMLHttpRequest();
    var path = 'https://localhost:5001/api/valueCode/' + code;
    xhr.open('GET', path, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.setRequestHeader('Accept', 'application/json');
    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    xhr.send();

    xhr.onreadystatechange = function() {
    if (xhr.readyState != 4) {
        return
    }

    if (xhr.status === 200) {
        var res = JSON.parse(xhr.responseText);
        alert("id:" + res.id);

        console.log('result', JSON.parse(xhr.responseText))
    }else {
        console.log('error', xhr.responseText)
    }
    }   
 }