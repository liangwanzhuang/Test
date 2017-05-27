using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLDAL;
using System.Data;

namespace ModelInfo
{
    public class TisanInfoModel
    {
        public DataBaseLayer db = new DataBaseLayer();
        public DataTable GetTisanInfio(int Page,int PageCount  )
        {
            string str = "select top " + PageCount + " p.ID as 处方序号,p.Pspnum as 处方号,p.decscheme 煎药方案,p.takenum as 次数,p.getdrugtime as 取药时间,p.getdrugnum as 取药号,p.takemethod 服用方法,p.dotime as 下单时间,p.dose as 付数,p.oncetime as 一煎时间,p.twicetime as 二煎时间,p.packagenum as 包装量,p.doctor as 医生,p.ordertime,p.curstate as 当前状态,p.remark as 备注,p.RemarksA as备注A,p.RemarksB 备注B,p.dtbcompany as 快递公司,p.dtbaddress as 收件地址,p.dtbphone as 收件电话,p.dtbtype,p.soaktime as 泡药时间,(select ReviewPer  from Audit as a where a.pid = p.ID ) as 复核人,(select AuditTime  from Audit as a where a.pid = p.ID ) as 复合时间,(select bubbleperson from  bubble as b where  b.pid=p.ID ) as 泡药人,(select endDate from  bubble as b where  b.pid=p.ID ) as 泡药结束时间,(select starttime from  bubble as b where  b.pid=p.ID ) as 泡药开始,p.Hospitalid as 医院id,p.name as 姓名,p.sex as 性别 ,p.age as 年龄,p.phone as 电话,p.address as 地址,p.department as 科室,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as 医院名称,p.diagresult as 诊断结果,(select tisaneman from tisaneinfo as t  where  t.pid=p.ID) as 煎药人,(select machinename from machine where id = (select machineid from tisaneunit where pid = p.id )) as 煎药机编号,(select starttime from tisaneinfo as t  where  t.pid=p.ID) as 煎药开始时间,(select endDate from tisaneinfo as t  where  t.pid=p.ID) as 煎药结束时间,(select jiefangman from jfInfo as ll where ll.pid = p.id ) as 煎药人员,  ( select Sendpersonnel from Delivery as d  where d.DecoctingNum  =p.ID ) as 发货人员 ,( select SendTime from Delivery as d  where d.DecoctingNum  =p.ID ) as 发货时间 ,(select Starttime  from Packing as m where m.DecoctingNum=p.ID ) as 包装结束时间,(select PacTime  from Packing as m where m.DecoctingNum=p.ID ) as 包装开始时间,(select Pacpersonnel  from Packing as m where m.DecoctingNum=p.ID ) as 包装人员,( select machinename  from machine   where  mark =1 and unitnum in (select unitnum from machine where id in (select machineid from tisaneunit as t where t.pid =p.id))) as 包装机编号,(select SwapPer  from adjust as a where a.prescriptionId=p.ID ) as 调剂人员,(select endDate  from adjust as a where a.prescriptionId=p.ID ) as 调剂结束时间,(select wordDate  from adjust as a where a.prescriptionId=p.ID ) as wordDate ,(select PartyPer  from PrescriptionCheckState as x where x.prescriptionId=p.ID ) as 审核人员 ,(select refusalreason  from PrescriptionCheckState as x where x.prescriptionId=p.ID ) as refusalreason,(select checkStatus  from PrescriptionCheckState as x where x.prescriptionId=p.ID ) as checkStatus from prescription as p  order by id desc ";
            string str2 = "select top " + PageCount + " * from prescription as w where ordertime>='2017-03-20'  and w.ID not in (select top " + (Page - 1) * PageCount + "  ID from prescription where ordertime >2017-03-20)";
            //根据ID计算出(Page-1)页的最小值，然后用TOP关键字及可解决问题
            return db.get_DataTable(str2);
        }

    }
}