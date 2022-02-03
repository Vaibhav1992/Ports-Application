import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
declare var $: any;

@Component({
  selector: 'app-port',
  templateUrl: './port.component.html',
  styleUrls: ['./port.component.css']
})
export class PortComponent implements OnInit {
  ports: any[] = [];
  name: string = "";
  portId: string = "";
  code: string= ""
  now:Date = new Date();
  pageNum: number = 0;
  recordsPerPage: number = 50;
  portsCount:Number = 0;
  constructor(private httpClient: HttpClient, private titleService: Title,private route: ActivatedRoute) {
    this.titleService.setTitle('Ports Application');
  }
  ngOnInit(): void {
    this.now = new Date();
    this.route.queryParams.subscribe((q) => {
      if (q['portId'] != null) {
        this.portId = q['portId'];
      }
    });

    this.GetPorts();
  }

  getDate(date: number){
      return new Date(date * 1000);
  }

  GetPorts(){
    let params = new HttpParams();
    params = params.append("Id",this.portId?.trim());
    params = params.append("Name",this.name?.trim());
    params = params.append("Code",this.code?.trim());
    params = params.append("PageNum",this.pageNum.toString());
    params = params.append("RecordsPerPage",this.recordsPerPage.toString());
    this.httpClient.get<any>(environment.apiUrl + 'ports', {params:params})
      .subscribe(arg => {
        this.portsCount = arg?.count;
        this.ports =  this.ports.concat(arg.ports);
        this.pageNum = arg?.nextPage;
      });
  }
  viewAllPorts(portId: any) {
    this.portId = portId;
    this.search();
  }

  search(){
    this.ports = [];
    this.pageNum = 0;
    this.GetPorts();
  }

  delete(id:any){
    if (window.confirm("Are you sure you want delete this port? You wont be able to undo this action.")) {
      let params = new HttpParams();
      params = params.append("portId",id);
      this.httpClient.delete<boolean>(environment.apiUrl + 'ports', {params: params}).subscribe({
        next:() => {
        this.ports = [];
        this.pageNum = 0;
        this.GetPorts();
        alert("Deleted Successfully.");
    },error: () => { alert("Failed to delete the port.")}});
    }
  }
}
