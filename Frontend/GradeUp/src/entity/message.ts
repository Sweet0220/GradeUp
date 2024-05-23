export class Message {
  public id: number = 0;
  public text: string = "";
  public chatId: number = 0;
  public userId: number = 0;
  public hour: string = "";
  public sendDate: Date = new Date();

  constructor() {
  }
}
